using System;

namespace Construction.DesignPatterns
{
    public class ResourcePoolConfig
    {
        public string Name { get; set; }
        public int MaxTotal { get; set; }
        public int MaxIdle { get; set; }
        public int MinIdle { get; set; }

        public ResourcePoolConfig(string name, int maxTotal, int maxIdle, int minIdle)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (maxTotal < 0)
            {
                throw new ArgumentException($"{nameof(maxTotal)} should not be negative");
            }

            if (maxIdle < 0)
            {
                throw new ArgumentException($"{nameof(maxIdle)} should not be negative");
            }

            if (minIdle < 0)
            {
                throw new ArgumentException($"{nameof(minIdle)} should not be negative");
            }

            if (MinIdle > MaxIdle)
            {
                throw new ArgumentException($"{nameof(MinIdle)} should not be greater than {nameof(MaxIdle)}");
            }

            Name = name;
            MaxTotal = maxTotal;
            MaxIdle = maxIdle;
            MinIdle = minIdle;
        }

        public override string ToString()
        {
            return $"Name is {Name}, MaxTotal is {MaxTotal}, MaxIdle is {MaxIdle}, MinIdle is {MinIdle}";
        }
    }
    

    public class ResourcePoolConfigRefactoring
    {
        public string Name { get; }
        public int MaxTotal { get; }
        public int MaxIdle { get; }
        public int MinIdle { get; }

        public ResourcePoolConfigRefactoring(ResourcePoolConfigBuilder builder)
        {
            Name = builder.Name;
            MaxTotal = builder.MaxTotal;
            MaxIdle = builder.MaxIdle;
            MinIdle = builder.MinIdle;
        }

        public override string ToString()
        {
            return $"Name is {Name}, MaxTotal is {MaxTotal}, MaxIdle is {MaxIdle}, MinIdle is {MinIdle}";
        }
    }

    public class ResourcePoolConfigBuilder
    {
        public string Name { get; private set; }
        public int MaxTotal { get; private set; }
        public int MaxIdle { get; private set; }
        public int MinIdle { get; private set; }

        public ResourcePoolConfigBuilder SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            return this;
        }

        public ResourcePoolConfigBuilder SetMaxTotal(int maxTotal)
        {
            if (maxTotal < 0)
            {
                throw new ArgumentException($"{nameof(maxTotal)} should no be negative");
            }

            MaxTotal = maxTotal;

            return this;
        }

        public ResourcePoolConfigBuilder SetMaxIdle(int maxIdle)
        {
            if (maxIdle < 0)
            {
                throw new ArgumentException($"{nameof(maxIdle)} should no be negative");
            }

            MaxIdle = maxIdle;

            return this;
        }

        public ResourcePoolConfigBuilder SetMinIdle(int minIdle)
        {
            if (minIdle < 0)
            {
                throw new ArgumentException($"{nameof(minIdle)} should no be negative");
            }

            MinIdle = minIdle;

            return this;
        }

        public ResourcePoolConfigRefactoring Builder()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentNullException(nameof(Name));
            }

            if (MinIdle > MaxIdle)
            {
                throw new ArgumentException($"{nameof(MinIdle)} should not be greater than {nameof(MaxIdle)}");
            }

            return new ResourcePoolConfigRefactoring(this);
        }
    }
}