namespace Section02 {
    internal class Program {
        static void Main(string[] args) {

            var appVer1 = new AppVersion(5, 1, 3, 123);
            var appVer2 = new AppVersion(5, 1, 3);
            if (appVer1 == appVer2) {
                Console.WriteLine("等しい");
            } else {
                Console.WriteLine("等しくない");
            }
        }
    }



    public record AppVersion(int major, int minor, int build = 0, int revision = 0) {
        public int Major { get; init; } = major;
        public int Minor { get; init; } = minor;
        public int Build { get; init; } = build;
        public int Revision { get; init; } = revision;

        //public AppVersion(int major, int minor)
        //    : this(major, minor, 0, 0) {  //- 引数4つのコンストラクターを呼び出す
        //}

        //public AppVersion(int major, int minor, int build)
        //    : this(major, minor, build, 0) {  //- 引数4つのコンストラクターを呼び出す
        //}

        //public AppVersion(int major, int minor, int build = 0, int revision = 0) {
        //    Major = major;
        //    Minor = minor;
        //    Build = build;
        //    Revision = revision;
        //}

        public override string ToString() =>
            $"{Major}.{Minor}.{Build}.{Revision}";

    }
}
