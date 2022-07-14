namespace TodoList.Models.Common;

public class PaginationInfo
{
  public static PaginationInfo GetPagination(int pageNo, int totalCnt, int pageSize = 10, int pageNumPerOnce = 10)
  {
    var result = new PaginationInfo()
    {
      PageNo = pageNo,
      TotalCnt = totalCnt,
      PageSize = pageSize,
      PageNumPerOnce = pageNumPerOnce
    };

    return result;
  }

  /// 현재 페이지 번호
  public int PageNo { get; set; }

  /// 한번에 보일 Pagination 개수
  public int PageNumPerOnce { get; set; } = 10;
  /// 총 게시물 개수
  public int TotalCnt { get; set; }

  /// 한번에 보일 게시물 개수
  public int PageSize { get { return this.PageSize; } set { PageSize = value <= 0 ? 1 : value; } }

  /// 마지막 Pagination 번호
  public int MaxPageNum { get { return TotalCnt % PageSize == 0 ? TotalCnt / PageSize : TotalCnt / PageSize + 1; } }

  /// 이전 버튼 여부
  public bool IsPrev { get { return PageNo != 1; } }

  /// 다음 버튼 여부
  public bool IsNext { get { return CurrentMaxPageNum < MaxPageNum; } }

  /// Pagination 범위 (최소)
  public int CurrentMinPageNum { get { return ((PageNo - 1) / PageNumPerOnce) * PageNumPerOnce; }}

  /// Pagination 범위 (최대)
  public int CurrentMaxPageNum { get { return CurrentMinPageNum + PageNumPerOnce; }}
}