using System;
using System.ComponentModel.DataAnnotations;
namespace ProiectFinal.Models.LibraryViewModels
{
    public class ClientsGroup
    {
        [DataType(DataType.Date)]
        public string? TrainingName { get; set; }
        public int ClientCount { get; set; }
    }
}