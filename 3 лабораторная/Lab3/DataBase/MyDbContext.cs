using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Lab3.DataBase
{
    /// <summary>
    /// Чувак, который работает с БД. С помощью классов, я указал таблицы и зависимости в них(смотри классы, которые описывают таблицы)
    /// </summary>
    public sealed class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        /// <summary>
        /// Set и DbSet - достает и запоминает что за проекты лежат в таблицах
        /// </summary>
        private DbSet<Project> Projects => Set<Project>();
        private DbSet<Objective> Tasks => Set<Objective>();
        private DbSet<Worker> Workers => Set<Worker>();
        /// <summary>
        /// 2 метода ниже, нужны, что бы наши проекты были в удобном формате для нас и с подгруженными связями. Сначала мы подключаем зависимости:
        /// Include(item => item.Tasks) - подключаем зависимость тасок
        /// ThenInclude(task => task.Worker) - в подключенных тасках, подтягивает работников, ну а ToListAsync преобразует к листу)
        /// Зачем подтягивать? Затем, что Entyty Framework не выкачивает всю бд целиком, а только по "подребности" называется это "ленивой загрузкой"
        /// Нам для работы нужно сразу подтянуть нужные данные, поэтому, делаем это явно
        /// </summary>
        /// <returns></returns>
        public async Task<List<Project>> GetAllProjects() => await Projects.Include(item => item.Tasks).ThenInclude(task => task.Worker).ToListAsync();
        public async Task<List<Worker>> GetAllWorkers() => await Workers.ToListAsync();
        /// <summary>
        /// Начиная с этого метода и ниже, мы просто получаем на вход данные, проверяем их на валидность, а затем
        /// выполняем действие, сохраняя БД, они однотипны, Если вдруг что, то я подскажу
        /// </summary>
        public async Task CreateProject(Project project)
        {
            await Projects.AddAsync(project);
            await SaveChangesAsync();
        }
        public async Task DeleteProject(int projectId)
        {
            var DbProject = await Projects.FirstOrDefaultAsync(p => p.Id == projectId);
            if (DbProject == null)
            {
                Console.WriteLine("Такого проекта нет");
                return;
            }
            foreach (var task in DbProject.Tasks)
            {
                Tasks.Remove(task);
            }
            Projects.Remove(DbProject);
            await SaveChangesAsync();
        }
        public async Task UpdateProject(Project project)
        {
            var DbProject = await Projects.FirstOrDefaultAsync(p => p.Id == project.Id);
            if (DbProject == null)
            {
                Console.WriteLine("Такого проекта нет");
                return;
            }
            DbProject.FullNameExecutor = project.FullNameExecutor;
            DbProject.FullNameSupervisor = project.FullNameSupervisor;
            DbProject.NameCustomerCompany = project.NameCustomerCompany;
            DbProject.NamePerformerCompany = project.NamePerformerCompany;
            DbProject.NameProject = project.NameProject;
            DbProject.TheDateOfTheBeginning = project.TheDateOfTheBeginning;
            DbProject.ExpirationDate = project.ExpirationDate;
            DbProject.Priority = project.Priority;
            await SaveChangesAsync();
        }

        public async Task AddTaskToProject(Project project, Objective task)
        {
            var DbProject = await Projects.FirstOrDefaultAsync(p => p.Id == project.Id);
            if (DbProject == null)
            {
                Console.WriteLine("Такого проекта нет");
                return;
            }
            task.Project = DbProject;
            Tasks.Add(task);
            await SaveChangesAsync();
        }
        public async Task DeleteTaskToProject(Project project, Objective task)
        {
            var DbProject = await Projects.FirstOrDefaultAsync(p => p.Id == project.Id);
            if (DbProject == null)
            {
                Console.WriteLine("Такого проекта нет");
                return;
            }
            var ProjectTask = DbProject.Tasks.FirstOrDefault(t => t.Id == task.Id);
            ProjectTask.Worker = null;
            DbProject.Tasks.Remove(task);
            await SaveChangesAsync();
        }
        public async Task UpdateTaskToProject(Project project, Objective task)
        {
            var DbProject = await Projects.FirstOrDefaultAsync(p => p.Id == project.Id);
            if (DbProject == null)
            {
                Console.WriteLine("Такого проекта нет");
                return;
            }
            var ProjectTask = DbProject.Tasks.FirstOrDefault(t => t.Id == task.Id);
            if (ProjectTask == null)
            {
                Console.WriteLine("Такой задачи нет");
                return;
            }
            ProjectTask.Name = task.Name;
            ProjectTask.Status = task.Status;
            ProjectTask.Worker = task.Worker;
            await SaveChangesAsync();
        }
        public async Task AddWorker(Worker worker)
        {
            Workers.Add(worker);
            await SaveChangesAsync();
        }
        public async Task DeleteWorker(Worker worker)
        {
            if (worker.Task != null)
            {
                var task = Tasks.FirstOrDefault(task => task.Id == worker.Task.Id);
                if (task != null) task.Worker = null;
            }
            Workers.Remove(worker);
            await SaveChangesAsync();
        }
    }
}
