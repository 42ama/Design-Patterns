using System;
using Autofac;
using Autofac.Core;
using DI_IoC_Autofac.Being;
using DI_IoC_Autofac.BodyPart.Implementation;
using DI_IoC_Autofac.BodyPart.Interface;

namespace DI_IoC_Autofac
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сегодня с помощью запатентованного DI IOC фреймворка AutoFac " +
                              "мы соберем целую кучу покемонов!\n");

            // Билдер используемый при построении контейнеров.
            ContainerBuilder builder;
            // Какой-то конкретный контейнер.
            IContainer container;

            #region ConstructiorInjection

            Console.WriteLine("Начиная с Сконструированных покемонов!(Constructor injection)\n\n");

            // Создаем новый DI-IoC контейнер.
            builder = new ContainerBuilder();

            // Регистрируем в нем необходимые типы. Среди перегрузок конструктора ConstructorBeing
            //  автоматически выбирается оптимальная.
            builder.RegisterType<ConstructorBeing>();
            builder.RegisterType<Arm>().As<ILimb>();
            builder.RegisterType<ReptilianBrain>().As<IBrain>();

            Console.WriteLine("Этот покемон взял мозг и конечность.");

            // Начинаем работу в рамках контейнера.
            container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                // Constructor injection, выберется наиболее подходящая перегрузка конструктора
                // исходя из зарегистрированных компонентов. (ILimb, IBrain)
                var constructorBeing = scope.Resolve<ConstructorBeing>();
                Console.WriteLine($"Покемон, расскажи о себе: {constructorBeing.ConstructStatus}");
            }


            // Создаем новый DI-IoC контейнер.
            builder = new ContainerBuilder();

            // Регистрируем в нем необходимые типы. ConstructorBeing регистрируется с использованием
            //  определенного конструктора.
            builder.RegisterType<ConstructorBeing>().UsingConstructor(typeof(IBrain));
            builder.RegisterType<Arm>().As<ILimb>();
            builder.RegisterType<ReptilianBrain>().As<IBrain>();

            Console.WriteLine("Этот покемон хотел взять конечность, но мы дали только мозг.");

            // Начинаем работу в рамках контейнера.
            container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                // Constructor injection, выберется конструктор выбранный
                // регистрации компонента. (IBrain)
                var constructorBeing = scope.Resolve<ConstructorBeing>();
                Console.WriteLine($"Покемон, расскажи о себе: {constructorBeing.ConstructStatus}");
            }
            #endregion

            #region PropertyInjection

            Console.WriteLine("\n\nПокемоны с удивительными свойствами!(Property injection)\n");

            // Создаем новый DI-IoC контейнер.
            builder = new ContainerBuilder();

            // Регистрируем в нем необходимые типы. Указываем, что хотим использовать Property injection.
            builder.RegisterType<PropertyBeing>().PropertiesAutowired();
            builder.RegisterType<Arm>().As<ILimb>();
            builder.RegisterType<ReptilianBrain>().As<IBrain>();

            Console.WriteLine("Этот покемон взял мозг и конечность.");

            // Начинаем работу в рамках контейнера.
            container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                // Property injection, свойства которые можно заполнить зарегистрированными
                // компонентами - будут заполнены. (ILimb, IBrain)
                var propertyBeing = scope.Resolve<PropertyBeing>();
                Console.WriteLine($"Мозг думает: {propertyBeing.Brain.ProduceThought()}, конечность {propertyBeing.Limb.Name} чешется. А органа во мне {propertyBeing.Organ != null}.");
            }
            #endregion

            #region ArrayInjection

            Console.WriteLine("\n\nКуча покемонов в одном!(Array injection)\n");

            // Создаем новый DI-IoC контейнер.
            builder = new ContainerBuilder();

            // Регистрируем в нем необходимые типы. Так как конструктор типа принимает массив
            //  элементов, то к нему автоматичски применется Array injection.
            builder.RegisterType<ArrayBeing>();
            builder.RegisterType<Arm>().As<ILimb>();
            builder.RegisterType<Leg>().As<ILimb>();
            builder.RegisterType<Tail>().As<ILimb>();

            Console.WriteLine("Этот покемон собрал все конечности.");

            // Начинаем работу в рамках контейнера.
            container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                // Array injection, коллекция передаваемая в конструкторе будет заполнена
                //  всеми зарегистрированными экземплярами компонента. (Arm, Leg, Tail)
                var arrayBeing = scope.Resolve<ArrayBeing>();
                Console.WriteLine($"В этого покемона положили такие конечности, как: {arrayBeing.GetNamesOfLimbs()}");
            }
            #endregion

            #region TransientLifetime

            Console.WriteLine("\n\nПокемоны однодневки!(Transient lifetime)\n");

            // Создаем новый DI-IoC контейнер.
            builder = new ContainerBuilder();

            // Регистрируем тип с transient областью видимости.
            builder.RegisterType<MetaBrain>().InstancePerDependency();

            // Начинаем работу в рамках контейнера.
            container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                for (int i = 0; i < 5; i++)
                {
                    // Каждый раз при вызове сервиса будет создан новый экземпляр.
                    Console.WriteLine("Рождаем новую однодневку");
                    var metaBrain = scope.Resolve<MetaBrain>();
                    Console.WriteLine($"Мозг покемона думает: {metaBrain.ProduceThought()}");
                }
            }

            Console.WriteLine("\n\nПокемоны бессмертные!(Singleton lifetime)\n");
            #endregion

            #region SingletonLifetime

            // Создаем новый DI-IoC контейнер.
            builder = new ContainerBuilder();

            // Регистрируем тип с singleton областью видимости.
            builder.RegisterType<MetaBrain>().SingleInstance();

            container = builder.Build();

            // Каждый раз при вызове сервиса будет использован существующий экземпляр в независимости
            //  от используемой области видимости сервиса. Если экземпляра нет - он будет создан.
            using (var scope = container.BeginLifetimeScope())
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("Пытаемся родить нового бессмертного...");
                    var metaBrain = scope.Resolve<MetaBrain>();
                    Console.WriteLine($"Мозг покемона думает: {metaBrain.ProduceThought()}");
                }
                
            }

            // В другой области видимости будет использоваться тот же самый экземпляр.
            using (var scope = container.BeginLifetimeScope())
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("Сильно тужимся и пытаемся родить нового бессмертного...");
                    var metaBrain = scope.Resolve<MetaBrain>();
                    Console.WriteLine($"Мозг покемона думает: {metaBrain.ProduceThought()}");
                }

            }

            Console.WriteLine("Но горец может быть только один.");
            #endregion

            #region ScopedLifetime

            // Создаем новый DI-IoC контейнер.
            builder = new ContainerBuilder();

            Console.WriteLine("\n\nПокемоны зависящие от угла взгляда!(Scoped lifetime)\n");

            // Регистрируем тип с scooped областью видимости.
            builder.RegisterType<MetaBrain>().InstancePerLifetimeScope();

            container = builder.Build();

            // Каждый раз при вызове сервиса будет использован существующий экземпляр.
            //  Между областями видимости сервиса, экземпляры будут различаться.
            using (var scope = container.BeginLifetimeScope())
            {
                Console.WriteLine("Смотрим на покемона под углом 89 градусов.");
                for (var i = 0; i < 5; i++)
                {
                    var metaBrain = scope.Resolve<MetaBrain>();
                    Console.WriteLine($"Мозг покемона думает: {metaBrain.ProduceThought()}");
                }
            }

            // Для другой области видимости создается новый экземпляр, но общий
            //  для все области видимости.
            using (var scope = container.BeginLifetimeScope())
            {
                Console.WriteLine("Смотрим на покемона под углом 90 градусов.");
                for (var i = 0; i < 5; i++)
                {
                    var metaBrain = scope.Resolve<MetaBrain>();
                    Console.WriteLine($"Мозг покемона думает: {metaBrain.ProduceThought()}");
                }
            }
            #endregion

            #region DependencyHierarchy
            Console.WriteLine("Закончим созависимыми покемонами!(иерархию зависимостей между классами)\n\n");

            // Создаем новый DI-IoC контейнер.
            builder = new ContainerBuilder();

            // Регистрируем в нем необходимые типы. Проверяем автоматическое разрешение
            //  зависимости в типе DependentBrain.
            builder.RegisterType<ConstructorBeing>().UsingConstructor(typeof(IBrain));
            builder.RegisterType<Arm>().As<ILimb>();
            builder.RegisterType<DependentBrain>().As<IBrain>();

            Console.WriteLine("Этот покемон взял мозг (который зацепился за конечность).");

            // Начинаем работу в рамках контейнера.
            container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                // DependentBrain имеет собственную зависимость от ILimb, которая
                // автоматически разрешается в рамках контейнера.
                var constructorBeing = scope.Resolve<ConstructorBeing>();
                Console.WriteLine($"Покемон, расскажи о себе: {constructorBeing.ConstructStatus}");
            }
            #endregion

            Console.WriteLine("\n(покемоны импортные - из Америки, перевода не завезли.)");

            Console.ReadKey();
        }
    }
}
