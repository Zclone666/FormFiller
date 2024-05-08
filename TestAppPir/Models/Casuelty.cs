using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppPir.Models
{
    [ProtoContract]
    public class Casuelty
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string SolderId { get; set; } = string.Empty;
        [ProtoMember(3)]
        public string NickName { get; set; } = string.Empty;
        [ProtoMember(4)]
        public string FullName {  get; set; } = string.Empty;
        [ProtoMember(5)]
        public string Name { get; set; } = string.Empty;
        [ProtoMember(6)]
        public string Surname { get; set; } = string.Empty;
        [ProtoMember(7)]
        public string LastName { get; set; } = string.Empty;
        [ProtoMember(8)]
        public string Destination {  get; set; } = string.Empty;
        [ProtoMember(9)]
        public string WoundType {  get; set; } = string.Empty;
        [ProtoMember(10)]
        public string WoundClause {  get; set; } = string.Empty;
        [ProtoMember(11)]
        public int WoundDate {  get; set; }
        [ProtoMember(12)]
        public int TimeOfDeath { get; set; }
        [ProtoMember(13)]
        public List<string> HelpProvided { get; set; } = new List<string>();
        [ProtoMember(14)]
        public string FileName { get; set; } = string.Empty;
        [ProtoMember(15)]
        public ushort FormId {  get; set; }
        [ProtoMember(16)]
        public string Complaints { get; set; } = string.Empty;
        [ProtoMember(17)]
        public string Anamnesis {  get; set; } = string.Empty;
        [ProtoMember(18)]
        public string Objectively { get; set;} = string.Empty;
        [ProtoMember(19)]
        public string Pharmacotherapy { get; set; } = string.Empty;
        [ProtoMember(20)]
        public string Preliminary_diagnosis {  get; set; } = string.Empty;
        [ProtoMember(21)]
        public string Recommendations { get; set; } = string.Empty;
        [ProtoMember(22)]
        public string ServiceType { get; set; } = string.Empty;
        [ProtoMember(23)]
        public string Specialist { get; set; } = string.Empty;
        [ProtoMember(24)]
        public string SituatedAt { get; set; } = string.Empty;
        [ProtoMember(25)]
        public int RecordDate { get; set; }
        [ProtoMember(26)]
        public int DateOfService { get; set; }
    }
}
