using System.ComponentModel.DataAnnotations.Schema;


namespace carelink_api.Models {

    [Table("refugee_family")] //The name in mysql, before I got wiser. 
    public class RefugeeFamily{
            public required int FamilyID { get; set; }
            public required int AsylumCardID { get; set; }

            public Refugee? Refugee { get; set; }


    }}