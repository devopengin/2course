using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08
{
    public delegate void ChangeLanguage(string Language);
    public delegate void ChangeVersion(int version);
    public class Programmer
    {

        public event ChangeLanguage? LanguageNameEvent;
        public event ChangeVersion? VersionEvent;
        public event ChangeLanguage? ClassificationEvent;

        private string NameOfLanguage { get; set; }
        private int VersionOfLanguage { get; set; }
        private string ClassificationOfLanguage { get; set; }
        public Programmer(string name, int version, string classificationOfLanguage)
        {
            NameOfLanguage = name;
            VersionOfLanguage = version;
            ClassificationOfLanguage = classificationOfLanguage;
        }

        public void ShowInf()
        {
            Console.WriteLine($"Язык программирования: {NameOfLanguage}, версия: {VersionOfLanguage}, классификация: {ClassificationOfLanguage}");
        }

        public void ChangeNameOfLanguage(string name)
        {
            NameOfLanguage = name;
            LanguageNameEvent?.Invoke(name);
        }
        public void ChangeVersionOfLanguage(int version)
        {
            VersionOfLanguage = version;
            VersionEvent?.Invoke(version);
        }
        public void ChangeClassificationOfLanguage(string classification)
        {
            ClassificationOfLanguage = classification;
            ClassificationEvent?.Invoke(classification);
        }

    }

}
