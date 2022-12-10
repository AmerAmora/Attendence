using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Attendence_System
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string foldername = now.ToString("dd-MM-yyyy");
            string dir = Server.MapPath($"Attend/{foldername}");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string path = Server.MapPath($"Attend/{foldername}");

            using (StreamWriter sw = File.AppendText($"{path}/SubmittedIDs.txt")) ;
        }
       


        protected void Attend(object sender, EventArgs e)
        {
            TimeSpan attendTime = new TimeSpan(14, 0, 0);
            TimeSpan arriveTime = DateTime.Now.TimeOfDay;
            DateTime now = DateTime.Now;
            string foldername = now.ToString("dd-MM-yyyy");
            string path = Server.MapPath($"Attend/{foldername}");
            int id =Convert.ToInt32 (userID.Value);
            string[] Employees = {
                "Ahmad Odat","Ahmad Hamaideh","Amer Amora","Ashraf Shwayat","Ayah AlZyout","Batool Al Dalki","Eman Alfokaha",
                "Faten Ksasbeh","Haitham Hazaymeh","Hassan Ayasrah", "Haya AlKhateeb","Lubna Alajlouni"," Lujain Alnouti"," Malek Obidat","Mayyas Obidat",
                "Moath Bdour", "Mohammad Swalha","Mohammad Al shraideh"," Momen AlAkhras","Momen Abo alhaija","Musab Ghannam", "Nsreen aldaraghmeh",
                "Nouran Omar","Odai al Ghaniem","Qais Darabseh", "Raghad Alghoul","Raghad Alrshdan","Rahma Obidat","Rama Shararah","Razan Smadi",
                "Roa'a Hameedat","Rogina Irshidat","Suhaib Alrousan","Wesam Abu Shaqra","Yazeen Aldamen"
            };
            if (id > 35 || id < 1) 
            {
                testLabel.InnerText = "ID must be between 35 and 0";
                return;
            }
            string[] lines = File.ReadAllLines($"{path}/SubmittedIDs.txt");
            foreach (string line in lines)
            {
                if (Convert.ToInt32(line) == id) 
                {
                    testLabel.InnerText = "You Already Submitted Today";
                    return;

                }
            
            }
            testLabel.InnerText = "";
            if (arriveTime > attendTime)
            {
                
                TimeSpan late = arriveTime.Subtract(attendTime);

                using (StreamWriter sw = File.AppendText($"{path}/late.txt"))
                {
                    sw.WriteLine("Employee id : " + id + "  Employee Name : " + Employees[id-1] + " Arrival time = " + arriveTime.ToString(@"hh\:mm") + " Late by = "+ late.ToString(@"hh\:mm"));
                    
                }
            }
            else 
            {
                using (StreamWriter sw = File.AppendText($"{path}/onTime.txt"))
                {
                    sw.WriteLine("Employee id : " + id + "  Employee Name : " + Employees[id - 1] + " Arrival time = " + arriveTime.ToString(@"hh\:mm"));

                }
            }
            using (StreamWriter sw = File.AppendText($"{path}/SubmittedIDs.txt"))
            {
                sw.WriteLine(id);

            }

        }
    }
}