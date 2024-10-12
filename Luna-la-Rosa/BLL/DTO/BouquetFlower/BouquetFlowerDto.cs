using BLL.DTO.Flower;

namespace BLL.DTO.BouquetFlower;

public class BouquetFlowerDto
{
    public int BouquetId { get; set; }
    public int FlowerId { get; set; }
    public int Quantity { get; set; }

    public FlowerDto Flower { get; set; }
}