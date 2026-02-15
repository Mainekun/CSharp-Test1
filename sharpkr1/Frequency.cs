namespace sharpkr1
{
    struct Frequency
    {
        public int days;
        public int weeks;
        public int months;

        public Frequency(int days, int weeks, int months)
        {
            this.days = days;
            this.weeks = weeks;
            this.months = months;
        }

        public Frequency()
        {
            days = 0;
            weeks = 0;
            months = 0;
        }

        public override string ToString()
        {
            return $"{days} day(s), {weeks} week(s), {months} month(es)";
        }

    }
}
