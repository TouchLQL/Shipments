namespace MultiColorPen.COMMON
{
    public class DataInfo : IDataInfo
    {
        public int totalcount { get; set; }
        public string rows { get; set; }
        public string msg { get; set; }
        
        public DataInfo()
        {
        }

        public DataInfo(int totalcount)
            : this(totalcount, null)
        {
        }

        public DataInfo(int totalcount, string rows)
        {
            this.totalcount = totalcount;
            this.rows = rows;
        }

        public DataInfo(int totalcount, string rows, string msg)
        {
            this.totalcount = totalcount;
            this.rows = rows;
            this.msg = msg;
        }
    }

    public class DataInfo<T> : DataInfo, IDataInfo<T>
    {
        public DataInfo()
        {
        }

        public DataInfo(int totalcount)
            : this(totalcount, null)
        {
        }

        public DataInfo(int totalcount, string rows)
            : base(totalcount, rows)
        {
        }

        public DataInfo(int totalcount, string rows, string msg)
            : base(totalcount, rows, msg)
        {
        }

        public T Entity { get; set; }
    }


    public interface IDataInfo
    {
        int totalcount { get; set; }
        string rows { get; set; }
    }

    public interface IDataInfo<T> : IDataInfo
    {
        T Entity { get; set; }
    }
}