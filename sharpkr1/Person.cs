namespace sharpkr1
{
    struct Person
    {
        public String firstName;
        public String lastName;

        public Person(String f, String s) 
        {
            firstName = f;
            lastName = s;
        }

        public override string ToString()
        {
			return $"{firstName} {lastName}";
        }
    }
}
