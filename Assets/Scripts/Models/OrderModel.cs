using System;

namespace Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }

        public string OrderState { get; set; } = string.Empty;  //Объявление, Заявка, Договор
        public string State { get; set; } = string.Empty;   //Груз = 1, Транспорт = 2, 
        public string Status { get; set; } = string.Empty;  //В поиске, Принят, В работе, Завершен

        public string Title { get; set; } = string.Empty;   //Название объявления
        public string Description { get; set; } = string.Empty;   //Описание объявления

        public float Rating { get; set; } = 0;   //Рейтинг создателя

        public bool ExecutorLeftReview { get; set; } = false; //Оставлял ли Исполнитель отзыв
        
        public string RegionFrom { get; set; } = string.Empty;  //Откуда
        public string CityFrom { get; set; } = string.Empty;

        public string RegionTo { get; set; } = string.Empty;    //Куда
        public string CityTo { get; set; } = string.Empty;

        public DateTime When { get; set; }  //Когда
        public DateTime DateCreated { get; set; } //Время создания заявки

        public string CargoType { get; set; } = string.Empty;   //Тип груза
        public string BodyType { get; set; } = string.Empty;    //Тип кузова

        public string Dimensions { get; set; } = string.Empty;  //Габариты
        public string Volume { get; set; } = string.Empty;  //Объем
        public string Weight { get; set; } = string.Empty;  //Вес

        public string Price { get; set; } = string.Empty;   //Цена
        public string Phone { get; set; } = string.Empty;   //Телефон

        public string PhotoImage { get; set; } = string.Empty;

        public Guid ExecuterId { get; set; }    //Id исполнителя
        public Guid OrderId { get; set; }   //Id на Заявку
        public Guid AgreementId { get; set; }   //Id на Заявку
        public Guid GarageId { get; set; }   //Id на Транспорт в гараже
        public Guid UserId { get; set; }

        public const string STATE_NAME_CARGO = "Груз";
        public const string STATE_NAME_TRANSPORT = "Транспорт";
    }
}
