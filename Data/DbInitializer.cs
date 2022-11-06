using System.Diagnostics;
using AppTest7.Models;
using System;
using System.Linq;

namespace AppTest7.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DalContext context)
        {
            context.Database.EnsureCreated();

            // Look for any todos.
            if (context.Todos.Any())
            {
                return;   // DB has been seeded
            }

            var todos = new Todo[]
            {
                new Todo{Name="Realizar pruebas de las apis", IsComplete=false},
                new Todo{Name="Crear una tabla User, con columnas, name, username, email, password", IsComplete=false},
                new Todo{Name="Crear una tabla Group, con columnas, groupName", IsComplete=false},
                new Todo{Name="Relacionar las tablas User y Group, de modo que casa User tenga un Group", IsComplete=false},
                new Todo{Name="Añadir JWT", IsComplete=false},
                new Todo{Name="Añadir CORS", IsComplete=false},
            };

            foreach (Todo s in todos)
            {
                context.Todos.Add(s);
            }

            context.SaveChanges();
        }
    }
}