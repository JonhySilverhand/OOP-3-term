using System;
using System.Collections.Generic;
using System.Text;

namespace Lab19_20
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    //Реализация интерфейса
    public class EditionOnCommand : ICommand
    {
        Edition Edition { get; set; }
        public EditionOnCommand(Edition edition)
        {
            Edition = edition;
        }

        public void Execute()
        {
            Edition.Add(Edition);
        }
        public void Undo()
        {
            Edition.Сanceled(Edition);
        }
    }
}
