namespace MultiColorPen.COMMON
{
    public class ResultInfo : IResultInfo
    {
        public bool IsSucceed { get; set; }
        public string Message { get; set; }
        public int TotalCount { get; set; }
        public decimal TotalCurr { get; set; }

        public ResultInfo()
        {
        }

        public ResultInfo(bool sSucceed)
            : this(sSucceed, null)
        {
        }

        public ResultInfo(bool isSucceed, string message)
        {
            this.IsSucceed = isSucceed;
            this.Message = message;
        }

        public ResultInfo(bool isSucceed, string message, int totalcount)
        {
            this.IsSucceed = isSucceed;
            this.Message = message;
            this.TotalCount = totalcount;
        }

        public ResultInfo(bool isSucceed, string message, int totalcount,decimal totalcurr)
        {
            this.IsSucceed = isSucceed;
            this.Message = message;
            this.TotalCount = totalcount;
            this.TotalCurr = totalcurr;
        }
    }

    public class ResultInfo<T> : ResultInfo, IResultInfo<T>
    {
        public ResultInfo()
        {
        }

        public ResultInfo(bool isSucceed)
            : this(isSucceed, null)
        {
        }

        public ResultInfo(bool isSucceed, string message)
            : base(isSucceed, message)
        {
        }

        public ResultInfo(bool isSucceed, string message, int totalcount)
            : base(isSucceed, message, totalcount)
        {
        }

        public ResultInfo(bool isSucceed, string message, int totalcount,decimal totalcurr)
            : base(isSucceed, message, totalcount, totalcurr)
        {
        }

        public T Entity { get; set; }

        public T Extend { get; set; }
    }


    public interface IResultInfo
    {
        bool IsSucceed { get; set; }
        string Message { get; set; }
    }

    public interface IResultInfo<T> : IResultInfo
    {
        T Entity { get; set; }
    }
}