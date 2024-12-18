using School.Core.Bases;
using School.Core.Dtos.Requests.StudentRequest;
using School.Core.Dtos.Responses.StudentResponse;
using School.Data.Constants.Enums;
using School.Data.Entities;

namespace School.Infrastructure.Implementations.Specifications.StudentSpecifications
{
    public class GetPaginationStudentSpecification : ISpecification<Student, StudentPaginationResponse>
    {
        public GetPaginationStudentSpecification(StudentPaginationRequest page) : base(x =>
        string.IsNullOrEmpty(page.Search)
        || x.NameAr.Contains(page.Search) || x.NameEn.Contains(page.Search) ||
        x.Address.Contains(page.Search) ||
        x.Phone.Contains(page.Search) ||
        x.Department.NameEn.Contains(page.Search)
        || x.Department.NameAr.Contains(page.Search))

        {
            AddInclude(x => x.Department);
            switch (page.OrderBy)
            {
                case StudentOrderingEnum.Id:
                    switch (page.TypeOfOrdering)
                    {
                        case TypeOfOrdering.Ascending:
                            AddOrderBy(x => x.Id);
                            break;
                        case TypeOfOrdering.Descending:
                            AddOrderByDescending(x => x.Id);
                            break;
                        default:
                            AddOrderBy(x => x.Id);
                            break;
                    }
                    break;
                case StudentOrderingEnum.NameAr:
                    switch (page.TypeOfOrdering)
                    {
                        case TypeOfOrdering.Ascending:
                            AddOrderBy(x => x.NameAr);
                            break;
                        case TypeOfOrdering.Descending:
                            AddOrderByDescending(x => x.NameAr);
                            break;
                        default:
                            AddOrderBy(x => x.NameAr);
                            break;
                    }
                    break;
                case StudentOrderingEnum.NameEn:
                    switch (page.TypeOfOrdering)
                    {
                        case TypeOfOrdering.Ascending:
                            AddOrderBy(x => x.NameEn);
                            break;
                        case TypeOfOrdering.Descending:
                            AddOrderByDescending(x => x.NameEn);
                            break;
                        default:
                            AddOrderBy(x => x.NameEn);
                            break;
                    }
                    break;
                case StudentOrderingEnum.Address:
                    switch (page.TypeOfOrdering)
                    {
                        case TypeOfOrdering.Ascending:
                            AddOrderBy(x => x.Address);
                            break;
                        case TypeOfOrdering.Descending:
                            AddOrderByDescending(x => x.Address);
                            break;
                        default:
                            AddOrderBy(x => x.Address);
                            break;
                    }
                    break;
                    break;
                case StudentOrderingEnum.Phone:
                    switch (page.TypeOfOrdering)
                    {
                        case TypeOfOrdering.Ascending:
                            AddOrderBy(x => x.Phone);
                            break;
                        case TypeOfOrdering.Descending:
                            AddOrderByDescending(x => x.Phone);
                            break;
                        default:
                            AddOrderBy(x => x.Phone);
                            break;
                    }
                    break;
                    break;
                case StudentOrderingEnum.DID:
                    switch (page.TypeOfOrdering)
                    {
                        case TypeOfOrdering.Ascending:
                            AddOrderBy(x => x.DID);
                            break;
                        case TypeOfOrdering.Descending:
                            AddOrderByDescending(x => x.DID);
                            break;
                        default:
                            AddOrderBy(x => x.DID);
                            break;
                    }
                    break;

                default:
                    switch (page.TypeOfOrdering)
                    {
                        case TypeOfOrdering.Ascending:
                            AddOrderBy(x => x.Id);
                            break;
                        case TypeOfOrdering.Descending:
                            AddOrderByDescending(x => x.Id);
                            break;
                        default:
                            AddOrderBy(x => x.Id);
                            break;
                    }
                    break;


            }


            AddSelector(x => new StudentPaginationResponse(x.GetName(), x.Address, x.Phone, x.Department == null ? null : x.Department.GetName()));




        }
    }
}
