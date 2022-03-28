using FantasySky.Core.Models;

namespace LibraryManagement.Manage.Abstractions.Models;

/// <summary>
/// 书本查询模型
/// </summary>
public record BookQueryModel : IQueryModel
{
    /// <summary>
    /// 书本编号
    /// </summary>
    public string? BookNo { get; set; }
    /// <summary>
    /// 书本名称
    /// </summary>
    public string? BookName { get; set; }
}