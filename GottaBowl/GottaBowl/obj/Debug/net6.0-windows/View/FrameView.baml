   M S B A M L   `   `   `  ????D  @GottaBowl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GottaBowl.ViewGottaBowl.View  5          GottaBowl.View.FrameView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:GottaBowl.View     5        ? 	Resources  5         BoolToVisibilityConverter??%   &	        ?? 5	   
   6'   5
      .??5      ? 
??????  ? ColumnDefinitions 5   
   ?? 5      $
??Auto ?6   .+?5   
   ??  ?? Orientation$ Vertical=?6   .+?5      ?? -   5         ??Name$ FrameNum??5      $??Center=?6D   ??6*   ?? *
FrameNum+6c   ?? 5      $ 
Horizontal=?6   .+?5      ?? -   5         ??Name$ 	FirstRoll??5   *   $??1??6   $??40??6^   ??6=   ?? *FirstRollString+6^   ?? 5      -   5        $ 
SecondRoll??5   *   $??2??6   $??40??6`   ??6>   ?? *SecondRollString+.??6k   ??5      ?? 5       ?? 
TargetType" ??6     ?? Triggers 5      ?? 5   "    ?? Binding 6.   ?? *Text+ ?? ElementName$ 	FirstRoll??	 ?? UpdateSourceTrigger$	 PropertyChanged=?
 ?? Value
  6?   .a?5   &   ??  ?? Property ? {? ?? Value$ False??6B   5   #   ^? 5   "    ^? 
Conditions 5   &   ?? 5   *    ?? Binding 64   ?? *Text+$ 	FirstRoll??$	 PropertyChanged=? ?? Value x6?   ?? 5   *    64   ?? *HasBonusRoll+	 False6U   .0?5   &   ??  ? {?$ False??6B   5    #   5"      .??5#   %   5$      ?? 5%      -   5        $ 	BonusRoll??5%   *   $??3??6   $??40??6?   ??6=   ?? *BonusRollString+y?6^   ?? *HasBonusRoll+ ?? 	Converter# [  .??6?   ??5&      ?? 5'      " ??6     5(      ?? 5)   "    6.   ?? *Text+$ 	FirstRoll??$	 PropertyChanged=?
  6?   .a?5*   &   ??  ? {?$ False??6B   5+   #   ?? 5,   "    6.   ?? *Text+$ 
SecondRoll??$	 PropertyChanged=?
  6?   .a?5-   &   ??  ? {?$ False??6B   5.   #   50      .??51   %   52      53      ?? 54      -   5        $ 
FrameScore??54      $??Center=?6C   ??6,   ?? *Score+6b   55      56      57      