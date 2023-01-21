using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TodoList.Models.BoardGame;

[Table("TB_BOARDGAME_HISTORY")]
public class BoardGameHistory
{
  [Key]
  [Column("ID")]
  public string Id { get; set; }

  [Column("GAME_NAME")]
  public string GameName { get; set; }

  [Column("GAME_SCORE")]
  public Dictionary<string, int> GameScore { get; set; }

  [Column("Winner")]
  public string Winner { get; set; }

  [Column("CREATE_DATE")]
  public DateTime? CreateDate { get; set; }
  [Column("UPDATE_DATE")]
  public DateTime? UpdateDate { get; set; }
}