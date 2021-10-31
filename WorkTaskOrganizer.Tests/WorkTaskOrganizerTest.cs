using System;
using Xunit;

namespace WorkTaskOrganizer.Tests
{
    public class WorkTaskOrganizerTest
    {
        [Fact]
        public void TestSumTimeRound()
        {            
            SumTimeRound inst1 = new SumTimeRound();
            SumTimeRound inst2 = new SumTimeRound();
            SumTimeRound inst3 = new SumTimeRound();
            SumTimeRound inst4 = new SumTimeRound();
            SumTimeRound inst5 = new SumTimeRound();
          

            inst1.AddHour(1);
            inst1.AddMin(30);
            inst2.AddHour(8);            
            inst3.AddHour(8);
            inst3.AddMin(1);            
            inst4.AddMin(60);            
            inst5.AddHour(8);
            inst5.AddHour(8);
            inst5.AddHour(8);
            inst5.AddHour(8);
            inst5.AddHour(8);


            Assert.Equal(0, inst1.getDays());
            Assert.Equal(1, inst1.getHours());
            Assert.Equal(30, inst1.getMins());
            Assert.Equal(1, inst2.getDays());
            Assert.Equal(0, inst2.getHours());
            Assert.Equal(0, inst2.getMins());
            Assert.Equal(1, inst3.getDays());
            Assert.Equal(0, inst3.getHours());
            Assert.Equal(1, inst3.getMins());
            Assert.Equal(0, inst4.getDays());
            Assert.Equal(1, inst4.getHours());
            Assert.Equal(0, inst4.getMins());
            Assert.Equal(5, inst5.getDays());
            Assert.Equal(0, inst5.getHours());
            Assert.Equal(0, inst5.getMins());
        }
    
        [Fact]
        public void TestSearchInFileScript()
        {
            string testParametr1 = "TestValue1";
            string testParametr2 = "T";
            string testParametr3 = "Parametr-_.,+[]{}";

            string testValue1 = "Value_TestValue1";
            string testValue2 = "Value_T";
            string testValue3 = "Value_Parametr-_.,+[]{}";

            string recivedValue1 = IOScripts.SearchInFile(testParametr1, "ConfigTest.txt");
            string recivedValue2 = IOScripts.SearchInFile(testParametr2, "ConfigTest.txt");
            string recivedValue3 = IOScripts.SearchInFile(testParametr3, "ConfigTest.txt");

            Assert.Equal(testValue1, recivedValue1);
            Assert.Equal(testValue2, recivedValue2);
            Assert.Equal(testValue3, recivedValue3);
        }
    

    }
}
