namespace DataCrawler
{
    public class JdCategory
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ParentCode { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Status { get; set; }
        public int CategoryLevel { get; set; }
    }
}