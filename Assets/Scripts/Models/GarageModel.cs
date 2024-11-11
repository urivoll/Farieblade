using System;
using UnityEngine;

namespace Models {
    public class GarageModel {
        public Guid Id { get; set; }
        public string State { get; set; } = string.Empty; //Ободрен, Отказан, Забанен
        public string Status { get; set; } = string.Empty; //Свободен, Занят, На проверке
        public string TransportType { get; set; } = string.Empty; //Легковой, Спец техника, Водный

        public string BodyType { get; set; } = string.Empty; //Тип кузова
        public string Brand { get; set; } = string.Empty; //Марка
        public string Model { get; set; } = string.Empty; //Модель
        public DateTime Year { get; set; } //Год
        public string CarryingCapacity { get; set; } = string.Empty; //Грузоподъемность

        public string EmptyFirst { get; set; } = string.Empty;
        public string EmptySecond { get; set; } = string.Empty;
        public string EmptyThird { get; set; } = string.Empty;

        public string AvtoImage { get; set; } = string.Empty;
        public string SvidetelstvoImage { get; set; } = string.Empty;
        public string PravaImage { get; set; } = string.Empty;

        public Guid UserId { get; set; }

        public GarageModel() {
        }

        public GarageModel(GarageModel model) {
            Id = model.Id;
            State = model.State;
            Status = model.Status;
            TransportType = model.TransportType;
            BodyType = model.BodyType;
            Brand = model.Brand;
            Model = model.Model;
            Year = model.Year;
            CarryingCapacity = model.CarryingCapacity;
            EmptyFirst = model.EmptyFirst;
            EmptySecond = model.EmptySecond;
            EmptyThird = model.EmptyThird;
            AvtoImage = model.AvtoImage;
            SvidetelstvoImage = model.SvidetelstvoImage;
            PravaImage = model.PravaImage;
            UserId = model.UserId;
        }

        public void PrintModel() {
            Debug.Log("---------------------------------------");
            Debug.Log("TransportType: " + TransportType);
            Debug.Log("Brand: " + Brand);
            Debug.Log("Model: " + Model);
            Debug.Log("Year: " + Year);
            Debug.Log("CarryingCapacity: " + CarryingCapacity);
            Debug.Log("BodyType: " + BodyType);
            Debug.Log("---------------------------------------");
        }
    }
}