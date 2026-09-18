using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.ExceptionHandling
{
    public class Try_Catch_Finally_Throw
    {
        public static void Run()
        {
            Building building = new Building();
            building.GetBuildingCost(100000000);
        }
    }

    public class Building
    {
        public int GetBuildingCost(int value )
        {
            try
            {
                return value / 0;
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
    }
}
