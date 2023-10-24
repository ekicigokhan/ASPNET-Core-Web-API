namespace Entities.DataTransferObjects
{
    /*[Serializable]*/ //Artık serileştirilebilir bir nesnedir. get ve set oldugu sürece gerek yok.
    public record BookDto
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public decimal Price { get; set; }
    }

    //record type : İmmutable olmalıdır.


}
