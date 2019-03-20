using System;
using System.Collections.Generic;
using System.Linq;

namespace Asap.DataAdapter
{
    public abstract class UpdatableAndLoadableAdapterBase<T, TCollection> : UpdatableAdapterBase<T>
        where TCollection : EditableDataObjectCollectionBase<T>, new()
    {
        public virtual T CreateNewData()
        {
            return (T)TypeCreator.CreateInstance(typeof(T));
        }

        /// <summary>
        /// 数据是否存在
        /// </summary>
        /// <param name="whereAction"></param>
        /// <returns></returns>
        public bool Exists(Action<WhereSqlClauseBuilder> whereAction)
        {
            whereAction.NullCheck("whereAction");

            WhereSqlClauseBuilder builder = new WhereSqlClauseBuilder();

            whereAction(builder);

            Dictionary<string, object> context = new Dictionary<string, object>();

            ORMappingItemCollection mappings = GetMappingInfo(context);

            string sql = string.Format("SELECT COUNT(*) FROM {0}", mappings.TableName);

            if (builder.Count > 0)
                sql = sql + string.Format(" WHERE {0}", builder.ToSqlString(TSqlBuilder.Instance));

            int count = (int)DbHelper.RunSqlReturnScalar(sql, GetConnectionName());

            return count > 0;
        }

        #region BatchUpdate

        public void BatchUpdate(TCollection data)
        {
            this.BatchUpdate(data, new Dictionary<string, object>());
        }

        public void BatchUpdate(TCollection data, Dictionary<string, object> context)
        {
            ExceptionHelper.FalseThrow<ArgumentNullException>(data != null, "data");
            if (context == null) context = new Dictionary<string, object>();

            data.ForEach(itemData => BeforeInnerUpdate(itemData, context));

            using (TransactionScope scope = TransactionScopeFactory.Create())
            {
                foreach (T itemData in data)
                {
                    if (InnerUpdate(itemData, context) == 0)
                        InnerInsert(itemData, context);

                    AfterInnerUpdate(itemData, context);
                }
                scope.Complete();
            }
            RefreshCache();
        }


        #endregion

        #region Load

        /// <summary>
        /// 按照条件加载对象
        /// </summary>
        /// <param name="whereAction">条件</param>
        /// <returns>对象集合</returns>
        public TCollection Load(Action<WhereSqlClauseBuilder> whereAction)
        {
            return Load(whereAction, null);
        }

        /// <summary>
        /// 按照In条件加载对象
        /// </summary>
        /// <param name="inAction"></param>
        /// <returns></returns>
        public TCollection LoadByInBuilder(Action<InSqlClauseBuilder> inAction)
        {
            return LoadByInBuilder(inAction, null);
        }

        /// <summary>
        /// 按照In条件加载对象
        /// </summary>
        /// <param name="inAction"></param>
        /// <param name="orderByAction"></param>
        /// <returns></returns>
        public TCollection LoadByInBuilder(Action<InSqlClauseBuilder> inAction, Action<OrderBySqlClauseBuilder> orderByAction)
        {
            inAction.NullCheck("whereAction");

            InSqlClauseBuilder builder = new InSqlClauseBuilder();

            inAction(builder);

            string condition = string.Empty;

            if (builder.Count > 0)
                condition = builder.ToSqlStringWithInOperator(TSqlBuilder.Instance);

            OrderBySqlClauseBuilder orderByBuilder = null;

            if (orderByAction != null)
            {
                orderByBuilder = new OrderBySqlClauseBuilder();

                orderByAction(orderByBuilder);
            }

            return InnerLoadByBuilder(condition, orderByBuilder);
        }

        /// <summary>
        /// 按照条件加载对象
        /// </summary>
        /// <param name="whereAction">筛选条件</param>
        /// <param name="orderByAction">排序条件</param>
        /// <returns>对象集合</returns>
        public TCollection Load(Action<WhereSqlClauseBuilder> whereAction, Action<OrderBySqlClauseBuilder> orderByAction)
        {
            whereAction.NullCheck("whereAction");

            WhereSqlClauseBuilder builder = new WhereSqlClauseBuilder();

            whereAction(builder);

            OrderBySqlClauseBuilder orderByBuilder = null;

            if (orderByAction != null)
            {
                orderByBuilder = new OrderBySqlClauseBuilder();

                orderByAction(orderByBuilder);
            }

            return InnerLoadByBuilder(builder.ToSqlString(TSqlBuilder.Instance), orderByBuilder);
        }

        private TCollection InnerLoadByBuilder(string condition, OrderBySqlClauseBuilder orderByBuilder)
        {
            Dictionary<string, object> context = new Dictionary<string, object>();

            ORMappingItemCollection mappings = GetMappingInfo(context);

            string sql = string.Format("SELECT * FROM {0}", mappings.TableName);

            if (condition.IsNotEmpty())
                sql = sql + string.Format(" WHERE {0}", condition);

            if (orderByBuilder != null && orderByBuilder.Count > 0)
                sql = sql + string.Format(" ORDER BY {0}", orderByBuilder.ToSqlString(TSqlBuilder.Instance));

            TCollection result = QueryData(sql);

            AfterLoad(result);

            return result;
        }

        /// <summary>
        /// 加载数据之后
        /// </summary>
        /// <param name="data"></param>
        protected virtual void AfterLoad(TCollection data)
        {
        }

        #endregion

        #region QueryData

        protected TDataCollection QueryData<TData, TDataCollection>(ORMappingItemCollection mapping, string sql)
            where TData : new()
            where TDataCollection : EditableDataObjectCollectionBase<TData>, new()
        {
            TDataCollection result = new TDataCollection();

            DataTable table = DbHelper.RunSqlReturnDS(sql, GetConnectionName()).Tables[0];

            foreach (DataRow row in table.Rows)
            {
                TData data = new TData();

                ORMapping.DataRowToObject(row, mapping, data);

                result.Add(data);
            }

            return result;
        }

        protected TCollection QueryData(string spName, params object[] parameterValues)
        {
            Dictionary<string, object> context = new Dictionary<string, object>();

            TCollection result = new TCollection();

            DataTable table = DbHelper.RunSPReturnDS(spName, parameterValues).Tables[0];

            ORMappingItemCollection mapping = GetMappingInfo(context);

            foreach (DataRow row in table.Rows)
            {
                T data = CreateNewData();

                ORMapping.DataRowToObject(row, mapping, data);

                if (data is ILoadableDataEntity)
                    ((ILoadableDataEntity)data).Loaded = true;

                result.Add(data);
            }

            return result;
        }

        protected TCollection QueryData(string sql)
        {
            Dictionary<string, object> context = new Dictionary<string, object>();

            TCollection result = new TCollection();

            DataTable table = DbHelper.RunSqlReturnDS(sql, GetConnectionName()).Tables[0];

            ORMappingItemCollection mapping = GetMappingInfo(context);

            foreach (DataRow row in table.Rows)
            {
                T data = CreateNewData();

                ORMapping.DataRowToObject(row, mapping, data);

                if (data is ILoadableDataEntity)
                    ((ILoadableDataEntity)data).Loaded = true;

                result.Add(data);
            }

            return result;
        }
        #endregion

        #region GetItem

        public virtual T GetItem(int key)
        {
            return CreateNewData();
        }

        #endregion

        #region GetCollection

        public virtual TCollection GetSourceCollection()
        {
            return new TCollection();
        }

        public TCollection GetCollection(Predicate<T> match)
        {
            TCollection collection = GetSourceCollection();
            return GetCollection(match, collection);
        }

        public TCollection GetCollection(Predicate<T> match, Comparison<T> comparison)
        {
            TCollection collection = GetSourceCollection();
            return GetCollection(match, collection, comparison);
        }

        public TCollection GetCollection(Predicate<T> match, TCollection collection)
        {
            return GetCollection(match, collection, null);
        }

        public TCollection GetCollection(Predicate<T> match, TCollection collection, Comparison<T> comparison)
        {
            TCollection result = new TCollection();
            if (collection != null)
            {
                if (comparison != null) collection.Sort(comparison);
                IList<T> lst = collection.FindAll(match);
                if (lst != null)
                    foreach (T item in lst) result.Add(item);
            }
            return result;
        }


        #endregion

    }
}
