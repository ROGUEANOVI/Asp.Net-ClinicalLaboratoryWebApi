namespace ClinicalLaboratory.Application.Commons.Bases
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public List<BaseError>? Errors { get; set; }
    }
}
