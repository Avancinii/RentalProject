using System.ComponentModel;

namespace MotorcycleRentalSystem.Enuns
{
    public enum Situation
    {
        [Description("Disponivel")]
        Disponivel = 1,
        [Description("Aceito")]
        Aceito = 2,
        [Description("Entregue")]
        Entregue = 3
    }
}
