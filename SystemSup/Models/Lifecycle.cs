using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SystemSup.Models
{
    // Модель жизенного цикла заявки
    public partial class Lifecycle
    {
        public Lifecycle()
        {
            Requests = new HashSet<Request>();
        }
        //Id
        public int Id { get; set; }
        // Дата открытия
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Opened { get; set; }
        // Дата распределения
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? Distributed { get; set; }
        // Дата обработки
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? Proccesing { get; set; }

        // Дата проверки
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? Checking { get; set; }
        // Дата закрытия
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? Closed { get; set; }

        public ICollection<Request> Requests { get; set; }
    }

    // Перечисление для статуса заявки
    public enum RequestStatus
    {
        Open = 1,
        Distributed = 2,
        Proccesing = 3,
        Checking = 4,
        Closed = 5
    }
    // Перечисление для приоритета заявки
    public enum RequestPriority
    {
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4
    }
}
