using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppPir.Models
{
    public class Fuckers
    {
        public string SolderId { get; set; }
        public string FullName {  get; set; }  
        public string Name { get; set; } 
        public string Surname { get; set; }
        public string LastName { get; set; }
        public string Destination {  get; set; }
        public string WoundType {  get; set; }
        public string WoundClause {  get; set; }
        public long WoundDate {  get; set; }
        public long TimeOfDeath { get; set; }
        public List<string> HelpProvided { get; set; }
        public string filename { get; set; }
    }
}
