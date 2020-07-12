using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ExpressionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //{
            //    new List<int>().Where(a => a > 10);
            //    new List<int>().AsQueryable().Where(a => a > 10);
            //}

            //{
            //    Func<int, int, int> func = (m, n) => m * n + 2;
            //    //Expression<Func<int, int, int>> exp = (m, n) => m * n + 2 + 3;
            //    Expression<Func<int, int, int>> exp = (m, n) => Sum(m, n);

            //    Console.WriteLine(func.Invoke(3, 5));
            //    Console.WriteLine(exp.Compile().Invoke(3, 5));
            //}

            //{
            //    ConstantExpression left = Expression.Constant(123, typeof(int));
            //    ConstantExpression right = Expression.Constant(32, typeof(int));
            //    var plus = Expression.Add(left, right);
            //    Expression<Func<int>> expression = Expression.Lambda<Func<int>>(plus, null);
            //    Console.WriteLine(expression.Compile().Invoke());
            //}

            //{
            //    var left = Expression.Constant(123, typeof(int));
            //    var right = Expression.Parameter(typeof(int));
            //    var plus = Expression.Add(left, right);
            //    var express = Expression.Lambda<Func<int, int>>(plus, new ParameterExpression[]
            //    {
            //        right
            //    });
            //    Console.WriteLine(express.Compile().Invoke(3));
            //}

            //{
            //    MethodInfo toString = typeof(int).GetMethod(nameof(int.ToString), new Type[] { });
            //    var constantExpr = Expression.Constant(123, typeof(int));
            //    MethodCallExpression method = Expression.Call(constantExpr, toString);
            //    Console.WriteLine(Expression.Lambda<Func<string>>(method, null).Compile().Invoke());
            //}

            //{
            //    var sql = $"select * from users";

            //    Console.WriteLine($"Input your name:");
            //    var name = Console.ReadLine();
            //    if (!string.IsNullOrEmpty(name))
            //    {
            //        sql += $" where name='{name}' ";
            //    }

            //    Console.WriteLine(sql);
            //}

            {
                //var dbSet = new List<People>().AsQueryable();

                //var sql = $"select * from users";
                //Expression<Func<People, bool>> exp = null;
                //Console.WriteLine($"Input your name:");
                //var name = Console.ReadLine();
                //if (!string.IsNullOrEmpty(name))
                //{
                //    exp = e => e.Name.Contains(name);
                //}

                //var sex = Console.ReadLine();
                //if (string.IsNullOrEmpty(sex))
                //{
                //    exp = e => e.Sex.Contains(sex);
                //    int b = 0;
                //    dbSet = dbSet.Where(a => Find(a, b));
                //}


                //Console.WriteLine(sql);
            }

            {
                People people = new People()
                {
                    Name = "chester",
                    Sex = "m"
                };
                //PeopleCopy peopleCopy = new PeopleCopy()
                //{
                //    Name = people.Name,
                //    Sex = people.Sex
                //};
                //PeopleCopy peopleCopy = Reflection<People, PeopleCopy>(people);
                //PeopleCopy peopleCopy = SerializeObj<People, PeopleCopy>(people);
                //PeopleCopy peopleCopy = ExpressionTrans<People, PeopleCopy>(people);

                //Console.WriteLine($"{peopleCopy.Name}");

                var expression = new OperationsVisitor();
                expression.Modify(p => p.Name == "dfaf" && p.Sex == "n" && p.Name == "afsaasf");

            }

            Console.WriteLine("Hello World!");
        }

        static bool Find(People a, int b)
        {
            return true;
        }

        static int Sum(int m, int n)
        {
            return m * n;
        }

        static TOut Reflection<TIn, TOut>(TIn @in)
        {
            TOut @out = Activator.CreateInstance<TOut>();
            foreach (var propertyInfo in @out.GetType().GetProperties())
            {
                var propIn = @in.GetType().GetProperty(propertyInfo.Name);
                propertyInfo.SetValue(@out, propIn.GetValue(@in));
            }
            return @out;
        }

        static TOut SerializeObj<TIn, TOut>(TIn @in)
        {
            return JsonConvert.DeserializeObject<TOut>(JsonConvert.SerializeObject(@in));
        }

        private static Dictionary<string, object> _Dic = new Dictionary<string, object>();
        static TOut ExpressionTrans<TIn, TOut>(TIn @in)
        {
            var key = $"funcKey_{typeof(TIn).FullName}_{typeof(TOut).FullName}";
            if (!_Dic.ContainsKey(key))
            {
                ParameterExpression parameterExpr = Expression.Parameter(typeof(TIn), "p");
                List<MemberBinding> memberBindings = new List<MemberBinding>();
                foreach (var propertyInfo in typeof(TOut).GetProperties())
                {
                    MemberExpression member =
                        Expression.Property(parameterExpr, typeof(TIn).GetProperty(propertyInfo.Name));
                    MemberBinding memberBinding = Expression.Bind(propertyInfo, member);
                    memberBindings.Add(memberBinding);
                }

                MemberInitExpression memberInit = Expression.MemberInit(Expression.New(typeof(TOut)), memberBindings.ToArray());
                Expression<Func<TIn, TOut>> expression = Expression.Lambda<Func<TIn, TOut>>(memberInit,
                    new ParameterExpression[]
                    {
                    parameterExpr
                    });
                Func<TIn, TOut> func = expression.Compile();
                _Dic.Add(key, func);
            }

            return ((Func<TIn, TOut>)_Dic[key]).Invoke(@in);
        }
    }

    class People
    {
        public string Name { get; set; }
        public string Sex { get; set; }
    }

    class PeopleCopy
    {
        public string Name { get; set; }
        public string Sex { get; set; }
    }

    class OperationsVisitor : ExpressionVisitor
    {
        public Expression Modify(Expression<Func<People, bool>> expression)
        {
            return this.Visit(expression);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            Console.WriteLine($"left:{node.Left.ToString()},nodeType: {node.NodeType.ToString()} and right: {node.Right.ToString()}");
            return base.VisitBinary(node);
        }
    }
}
