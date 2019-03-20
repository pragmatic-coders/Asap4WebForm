using Asap.Library.Interface;
using Asap.Library.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Linq.Expressions;

namespace Asap.Library.Core
{
    public interface IDataContext : IDisposable
    {
        bool IsFake { get; set; }
        void AddEntity<T>(T entity) where T : TopBasePoco;
        void UpdateEntity<T>(T entity) where T : TopBasePoco;
        void UpdateProperty<T>(T entity, Expression<Func<T, object>> fieldExp) where T : TopBasePoco;
        void UpdateProperty<T>(T entity, string fieldName) where T : TopBasePoco;
        void DeleteEntity<T>(T entity) where T : TopBasePoco;
        void CascadeDelete<T>(T entity) where T : TopBasePoco, ITreeData<T>;
        DbSet<T> Set<T>() where T : class;

        DbSet Set(Type entityType);

        string CSName { get; set; }
        int SaveChanges();
        Database Database { get; }
        void ChangeRelationTo<T, V>(T source, Expression<Func<T, List<V>>> navigation, List<Guid> oldIDs, List<Guid> newIDs)//, List<Guid> all = null)
            where T : TopBasePoco
            where V : TopBasePoco;
    }

    public partial class FrameworkContext : DbContext, IDataContext
    {

        public DbSet<Application> Applications { get; set; }

        public bool Commited { get; set; }
        public bool IsFake { get; set; }

        public string CSName { get; set; }
        public FrameworkContext()
            : base("name=default")
        {
            CSName = "default";
        }

        public FrameworkContext(string cs)
            : base(cs)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            CSName = cs;
        }

        /// <summary>
        /// 将一个实体设为填加状态
        /// </summary>
        /// <param name="entity">实体</param>
        public void AddEntity<T>(T entity) where T : TopBasePoco
        {
            this.Entry(entity).State = EntityState.Added;
        }

        /// <summary>
        /// 将一个实体设为修改状态
        /// </summary>
        /// <param name="entity">实体</param>
        public void UpdateEntity<T>(T entity) where T : TopBasePoco
        {
            this.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// 将一个实体的某个字段设为修改状态，用于只更新个别字段的情况
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="entity">实体</param>
        /// <param name="fieldExp">要设定为修改状态的字段</param>
        public void UpdateProperty<T>(T entity, Expression<Func<T, object>> fieldExp)
            where T : TopBasePoco
        {
            var set = this.Set<T>();
            if (set.Local.Where(x => x.ID == entity.ID).FirstOrDefault() == null)
            {
                set.Attach(entity);
            }
            this.Entry(entity).Property(fieldExp).IsModified = true;
        }

        public void UpdateProperty<T>(T entity, string fieldName)
            where T : TopBasePoco
        {
            var set = this.Set<T>();
            if (set.Local.Where(x => x.ID == entity.ID).FirstOrDefault() == null)
            {
                set.Attach(entity);
            }
            this.Entry(entity).Property(fieldName).IsModified = true;
        }

        /// <summary>
        /// 将一个实体设定为删除状态
        /// </summary>
        /// <param name="entity">实体</param>
        public void DeleteEntity<T>(T entity) where T : TopBasePoco
        {
            var set = this.Set<T>();
            if (set.Local.Where(x => x.ID == entity.ID).FirstOrDefault() == null)
            {
                set.Attach(entity);
            }
            set.Remove(entity);
        }
        public void CascadeDelete<T>(T entity) where T : TopBasePoco, ITreeData<T>
        {
            if (entity != null && entity.ID != Guid.Empty)
            {
                var set = this.Set<T>();
                var entities = set.Where(x => x.ParentID == entity.ID).ToList();
                if (entities.Count > 0)
                {
                    foreach (var item in entities)
                    {
                        CascadeDelete(item);
                    }
                }
                DeleteEntity(entity);
            }
        }

        /// <summary>
        /// 批量更改外键关系，将Navigation中的外键由oldIDs改变为newIDs
        /// </summary>
        /// <typeparam name="T">主类</typeparam>
        /// <typeparam name="V">外键关系引向的子类列表</typeparam>
        /// <param name="source">主类</param>
        /// <param name="navigation">指向子类</param>
        /// <param name="oldIDs">原有外键列表</param>
        /// <param name="newIDs">新外键列表</param>
        /// <example>
        /// 例如部门和员工是一对多的关系，假如原部门包括ID为1，2，3的三个员工，如果想将该部门包含的员工改成ID为3，4，5，6的员工
        /// 就可以使用本函数 ChangeRelationTo(Dep, x=>x.Users, new List<long>{1,2,3}, new List<long>{3,4,5,6});
        /// </example>
        public void ChangeRelationTo<T, V>(T source, Expression<Func<T, List<V>>> navigation, List<Guid> oldIDs, List<Guid> newIDs)
            where T : TopBasePoco
            where V : TopBasePoco
        {
            var ToRemove = new List<Guid>();//删除
            var ToAdd = new List<Guid>();//新增

            if (oldIDs == null)
            {
                oldIDs = new List<Guid>();
            }
            if (newIDs == null)
            {
                newIDs = new List<Guid>();
            }
            if (newIDs.Contains(Guid.Empty))
            {
                newIDs = this.Set<V>().Select(x => x.ID).ToList();
            }
            foreach (var oldItem in oldIDs)
            {
                bool exist = false;
                foreach (var newItem in newIDs)
                {
                    if (oldItem == newItem)
                    {
                        exist = true;
                        break;
                    }
                }
                if (exist == false)
                {
                    ToRemove.Add(oldItem);
                }
            }
            foreach (var newItem in newIDs)
            {
                bool exist = false;
                foreach (var oldItem in oldIDs)
                {
                    if (newItem == oldItem)
                    {
                        exist = true;
                        break;
                    }
                }
                if (exist == false)
                {
                    ToAdd.Add(newItem);
                }
            }
            this.Set<T>().Attach(source);
            foreach (var item in ToAdd)
            {
                V temp = typeof(V).GetConstructor(Type.EmptyTypes).Invoke(null) as V;
                temp.ID = item;
                this.Set<V>().Attach(temp);
                Expression<Func<T, object>> nav = Expression.Lambda<Func<T, object>>(navigation.Body, navigation.Parameters);
                ChangeRelation<T>(source, temp, nav, EntityState.Added);
            }
            foreach (var item in ToRemove)
            {
                V temp = typeof(V).GetConstructor(Type.EmptyTypes).Invoke(null) as V;
                temp.ID = item;
                this.Set<V>().Attach(temp);
                Expression<Func<T, object>> nav = Expression.Lambda<Func<T, object>>(navigation.Body, navigation.Parameters);
                ChangeRelation<T>(source, temp, nav, EntityState.Deleted);
            }
        }

        public void ChangeRelation<T>(T source, object target, Expression<Func<T, object>> navigation, EntityState state) where T : class
        {
            ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.ChangeRelationshipState<T>(source, target, navigation, state);
        }

        public void DisableChangeDetection()
        {
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        public void EnableChangeDetection()
        {
            this.Configuration.AutoDetectChangesEnabled = true;
        }

        public bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }


        public Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    if ("DateTime".Equals(t.GenericTypeArguments[0].Name))
                    {
                        return typeof(string);
                    }
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                if ("DateTime".Equals(t.Name))
                {
                    return typeof(string);
                }
                return t;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除EF默认的一对多级联删除设定
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //寻找所有MLContent的多语言类，把多语言的主表和子表设定为级联删除。
            //这样所有多语言的子表就不需要单独操作，不需要再DataContext中定义DbSet
            var modelAsms = Configs.AllAssembly;
            List<Type> allTypes = new List<Type>();
            foreach (var asm in modelAsms)
            {
                #region edit by wuwh 2014.09.24 修改因在ListVM属性上加Unicode等自定义标签生成数据库的问题
                var dcModule = asm.GetExportedTypes().Where(x => typeof(DbContext).IsAssignableFrom(x)).ToList();
                if (dcModule != null && dcModule.Count > 0)
                {
                    foreach (var module in dcModule)
                    {
                        foreach (var pro in module.GetProperties())
                        {
                            if (pro.PropertyType.GenericTypeArguments.Length > 0)
                            {
                                allTypes.Add(pro.PropertyType.GenericTypeArguments[0]);
                            }
                        }
                    }
                }
                //allTypes.AddRange(asm.GetExportedTypes().Where(x => x.IsSubclassOf(typeof(TopBasePoco))).ToList()); 
                #endregion
            }
            //找到所有的BasePoco相关的类，只有这些类会生成库
            for (int i = 0; i < allTypes.Count; i++)
            {
                var item = allTypes[i];
                var pros = item.GetProperties();
                foreach (var pro in pros)
                {
                    if (typeof(TopBasePoco).IsAssignableFrom(pro.PropertyType))
                    {
                        if (allTypes.Contains(pro.PropertyType) == false)
                        {
                            allTypes.Add(pro.PropertyType);
                        }
                    }
                    else
                    {
                        if (pro.PropertyType.IsGenericType && pro.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                        {
                            var inner = pro.PropertyType.GetGenericArguments()[0];
                            if (typeof(TopBasePoco).IsAssignableFrom(inner))
                            {
                                if (allTypes.Contains(inner) == false)
                                {
                                    allTypes.Add(inner);
                                }
                            }
                        }
                    }
                }
            }

            var CaModelAss = allTypes.Where(x => x.Assembly.FullName.ToLower().StartsWith("caframework.models,")).Select(x => x.Assembly).FirstOrDefault();



        }

    }
}
