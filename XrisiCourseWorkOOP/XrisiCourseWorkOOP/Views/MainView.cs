using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrisiCourseWorkOOP.Tools;
using XrisiCourseWorkOOP.Entity;
using XrisiCourseWorkOOP.DRRepo;


namespace XrisiCourseWorkOOP.Views
{
    class MainView
    {
        public void Add()
        {
            Console.Clear();

            DailyNoteEntity note = new DailyNoteEntity();

            Console.Write($"Date: {DateTime.Now}");
            note.Date = DateTime.Now;
            Console.Write("\nWrite note ID: ");
            note.ID = int.Parse(Console.ReadLine());
            Console.Write("Description: ");
            note.Description = Console.ReadLine();
            DailyNoteRepository noteRepo = new DailyNoteRepository("xrisidiary.txt");
            noteRepo.Save(note);
            Console.Clear();
            Console.WriteLine("Note saved successfully");
            Console.ReadKey(true);
            Console.Clear();
            MainView nowview = new MainView();
            nowview.ShowMenu();
        }
        public void SeeAll()
        {
            Console.Clear();
            DailyNoteRepository noteRepo = new DailyNoteRepository("xrisidiary.txt");
            List<DailyNoteEntity> notes = noteRepo.GetAll();
            Console.Write("****************************\n");
            foreach (DailyNoteEntity i in notes)
            {
                Console.WriteLine("Date:{0}", i.Date);
                Console.WriteLine("ID:{0}", i.ID);
                Console.WriteLine("Description:{0}", i.Description);
                Console.Write("****************************\n");
            }
            Console.ReadKey(true);
            Console.Clear();

            MainView nowview = new MainView();
            nowview.ShowMenu();
        }
        public DiaryEnum ShowMenu()
        {
            while (true)
            {
                DiaryEnum choice = RenderMenu();
                while (true)
                {
                    try
                    {
                        switch (choice)
                        {
                            case DiaryEnum.Add:
                                {
                                    Add();
                                    break;
                                }

                            case DiaryEnum.GetAll:
                                {
                                    SeeAll();
                                    break;
                                }

                            case DiaryEnum.Loggout:
                                {
                                    Environment.Exit(0);
                                    break;
                                }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.WriteLine(ex.Message);
                        Console.ReadKey(true);
                    }
                }
            }
        }
        private DiaryEnum RenderMenu()
        {
            while (true)
            {
                Console.WriteLine("[\u2665] Xrisi's Diary [\u2665] \nOwner: {0}, Date: {1}", OUAP.OwnerName, DateTime.Now);
                Console.WriteLine("\n[A]dd new DiaryNote");
                Console.WriteLine("[S]ee all DiaryNotes");
                Console.WriteLine("E[x]it");

                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {
                    case "A":
                        {
                            return DiaryEnum.Add;
                        }

                    case "S":
                        {
                            return DiaryEnum.GetAll;
                        }

                    case "X":
                        {
                            return DiaryEnum.Loggout;
                        }

                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid choice.");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }
    }
}