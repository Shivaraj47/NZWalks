namespace NZWalks.API.Model.DTO
{
    public class AddWalkRequestDTO
    {
        public string Name { get; set; }

        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }

    }
}
