
namespace SPADemo.Common.Expression
{
    public interface IPaginationExpression
    {
        int PageNumber { get; set; }

        int PageSize { get; set; }
    }
}