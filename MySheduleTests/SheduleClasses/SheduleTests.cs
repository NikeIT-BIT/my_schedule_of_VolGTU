using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyShedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests
{
    [TestClass()]
    public class SheduleTimeTests
    {
        [TestMethod()]
        public void PossibleAppointLessonRoomTest() { 
        //arange
        string nameRoom = "B-1403";
        List<string> disciplineLection = new List<string>() { "Алгоритмы и структуры данных", "Микропроцессоры и микроконтроллеры" };
        List<string> disciplineLabWork = new List<string>() { "Алгоритмы и структуры данных", "Микропроцессоры и микроконтроллеры" };
        List<string> disciplinePractice = new List<string>() { "Алгоритмы и структуры данных", "Микропроцессоры и микроконтроллеры" };
        bool lection = true;
        bool labWork = true;
        bool practice = true;
        SheduleRoom room = new SheduleRoom(nameRoom, disciplineLection, disciplineLabWork, disciplinePractice, lection, labWork, practice);
        List<SheduleRoom> rooms = new List<SheduleRoom>() { room };
        LessonType type = LessonType.Labwork;
        EducationLoadAdapter adapter = new EducationLoadAdapter();
        SettingShedule setting = new SettingShedule();
        Employments employments = new Employments();
        DateTime date = new DateTime();
        SheduleGenerator shedule = new SheduleGenerator(adapter, rooms, setting, date, employments);
        bool trueResult = true;
        //act
        bool testResult = shedule.PossibleAppointLessonRoom(room, type);
        //assert
        Assert.AreEqual(testResult, trueResult);
        }

        [TestMethod()]
    public void GetItemInfoTest(){

        //arange
        string teacher = "Андреев А.Е.";
        string discipline = "Современные ОС";
        List<String> groups = new List<string>() { "ЭВМ-1.1", "ЭВМ-1.2", "ЭВМ-1.3п" };
        decimal hours = 34;
       LoadItem item = new LoadItem(teacher, discipline, groups, hours, LessonType.Practice);

        List<SheduleRoom> rooms = new List<SheduleRoom>() { };
        EducationLoadAdapter adapter = new EducationLoadAdapter();
        SettingShedule setting = new SettingShedule();
        Employments employments = new Employments();
        SheduleTime time = new SheduleTime();
        employments.Add(teacher, groups, "ЭВМ-1.1", time, ReasonEmployment.Another);
        DateTime date = new DateTime();
        SheduleGenerator shedule = new SheduleGenerator(adapter, rooms, setting, date, employments);
        string trueResult = "Андреев А.Е., Современные ОС, ЭВМ-1.1/ЭВМ-1.2/ЭВМ-1.3п";

        //act
        string testResult = shedule.GetItemInfo(item);

        //assert
        Assert.AreEqual(testResult, trueResult);
        }

        [TestMethod]
        public void GetLessonTest()
        {
            //Arrange
            SheduleTime Time = new SheduleTime(Week.FirstWeek, Day.Saturday, 4);
            string room = "B-1403";
            var sheduleWeeks = new SheduleWeeks();
            //act
            SheduleLesson sheduleLesson = sheduleWeeks.GetLesson(Time, room);
            //assert
            Assert.IsNotNull(sheduleLesson);
        }


    }

   
}