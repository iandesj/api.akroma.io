namespace Akroma.Import
{
    public class SaveResult
    {
        public static SaveResult Success(bool exists = false)
        {
            return new SaveResult
            {
                Ok = true,
                Exists = exists
            };
        }

        public static SaveResult Error(bool exists)
        {
            return new SaveResult
            {
                Ok = false,
                Exists = exists
            };
        }
        public bool Ok { get; set; }
        public bool Exists { get; set; }
    }
}
