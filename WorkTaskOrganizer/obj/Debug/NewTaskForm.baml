   M S B A M L   `   `   `  ����L  HWorkTaskOrganizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WorkTaskOrganizerWorkTaskOrganizer  5   	   #    WorkTaskOrganizer.NewTaskForm   5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5	   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5
   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WorkTaskOrganizer     5   	   -   5          �Name$  window��5   6      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � Title$	 ---��5   	   $��423.043��6   $��796.348��6&    � 
ResizeMode$ NoResize=�6F    � WindowStartupLocation$ CenterScreen=�6\   
������  � AllowsTransparency .  � WindowStyle$
 None=�5   @   .��5      ��   MaterialDesignPaper#���  6    �� CornerRadius$ 10��6@   $��1q�6R   ���#eeee._�5   
   � .+�5      �� $��Task status��6   $
��Left=�6*   $��10,9,0,0q�6E   $	��Top=�6W   	� 5      -   5        	 	�Name$	 rbTaskStatusReloadOnProd��5      
 	� 	GroupName$
 
TaskStatus��6<   $��Reload on prod��6S   $
��Left=�6l   $��
11,150,0,0q�6�   $	��Top=�6�   	� 5      -   5        $	 rbTaskStatusQuestionToPM��5      $
 
TaskStatus��6<   $��Question to PM��6S   $
��Left=�6l   $��
10,104,0,0q�6�   $	��Top=�6�   	� 5      -   5        $	 rbTaskStatusOpen��5      $
 
TaskStatus��64   $
��Open��6K   $
��Left=�6Z   $��	10,58,0,0q�6u   $	��Top=�6�   	� 5      -   5        $	 rbTaskStatusClosed��5      $
 
TaskStatus��66   $��Closed��6M   $
��Left=�6^   $��	10,81,0,0q�6y   $	��Top=�6�   	� 5      -   5        $	 rbTaskStatusOnTests��5      $
 
TaskStatus��67   $��On tests��6N   $
��Left=�6a   $��
11,127,0,0q�6|   $	��Top=�6�   	� 5      -   5        $	 rbTaskStatusNotStarted��5      $
 
TaskStatus��6:   $��Not started��6Q   $
��Left=�6g   $��	10,35,0,0q�6�   $	��Top=�6�   �� 5      $��Priority��6   $
��Left=�6'   $��
10,186,0,0q�6B   $	��Top=�6V   	� 5      -   5        $	 rbTaskPriority1��5      $
 Priority��63   $��1 - Blocker��6H   $
��Left=�6^   $��
10,212,0,0q�6y   $	��Top=�6�   	� 5      -	   5        $	 rbTaskPriority2��5      $
 Priority��63   $��2 - Critical��6H   $
��Left=�6_   $��
10,235,0,0q�6z   $	��Top=�6�   	� 5      -
   5        $	 rbTaskPriority3��5      $
 Priority��63   $��	3 - Major��6H   $
��Left=�6\   $��
10,258,0,0q�6w   $	��Top=�6�   	� 5      -   5        $	 rbTaskPriority4��5      $
 Priority��63   $��	4 - Minor��6H   $
��Left=�6\   $��
10,281,0,0q�6w   $	��Top=�6�   	� 5      -   5        $	 rbTaskPriority5��5      $
 Priority��63   $��5 - Trivial��6H   $
��Left=�6^   $��
10,304,0,0q�6y   $	��Top=�6�   �� 5       $��Format��6   $
��Left=�6%   $��131,293,0,0q�6@   $	��Top=�6U   	� 5!      -   5        $	 rbTaskFormatE1��5!   9   $
 Format��6Q   $��E1��6d   $
��Left=�6q   $��131,319,0,0q�6�   $	��Top=�6�   	� 5"      -   5        $	 rbTaskFormatE2��5"   9   $
 Format��6Q   $��E2��6d   $
��Left=�6q   $��131,342,0,0q�6�   $	��Top=�6�   	� 5#      -   5        $	 rbTaskFormatAnother��5#   9   $
 Format��6V   $��Another��6i   $
��Left=�6{   $��131,365,0,0q�6�   $	��Top=�6�   �� 5$      -   5         ��Name$ tbxFormatAnother��5$      $
��Left=�60   $��22��6K   $��131,388,0,0q�6W    �� TextWrapping$
 Wrap=�6l   $�� ��6�   $	��Top=�6�   $	��290��6�   �� 5%      $��	Task name��6   $
��Left=�6(   $��	131,4,0,0q�6C   $	��Top=�6V   �� 5&      -   5        $ tbxTaskName��5&      $
��Left=�6+   $��23��6F   $��
131,30,0,0q�6R   $
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��290��6�   �� 5'      $��Link to Jira��6   $
��Left=�6+   $��
131,64,0,0q�6F   $	��Top=�6Z   �� 5(      -   5        $ tbxLinkToJira��5(      $
��Left=�6-   $��23��6H   $��
131,90,0,0q�6T   $
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��290��6�   �� 5)      $��Comment��6   $
��Left=�6&   $��	426,5,0,0q�6A   $	��Top=�6T   $��33��6l   �� 5*      -   5        $ 	tbxComent��5*      " �� VerticalScrollBarVisibility$
 Auto=�6*   $ �� HorizontalScrollBarVisibility$
 Auto=�6M    �� AcceptsReturn . $
��Left=�6�   $	��311��6�   $��
426,30,0,0q�6�   $ NoWrap=�6�   $�� ��6�   $	��Top=�6�   $	��359��6�   6  �� 5+      $��Catalog name��6   $
��Left=�6+   $��131,122,0,0q�6F   $	��Top=�6[   �� 5,      -   5        $ tbxCatalogName��5,      $
��Left=�6.   $��23��6I   $��131,148,0,0q�6U   $
 Wrap=�6j   $�� ��6~   $	��Top=�6�   $	��290��6�   (  "System.Windows.Controls.DatePicker  5-      -   5          Name$ calCreationDate��5-      $
��Left=�62   $��128,260,0,0q�6M   $	��Top=�6b   �� 5.      $��Creation date��6   $
��Left=�6,   $��128,229,0,0q�6G   $	��Top=�6\     5/      -   5        $ calDeadline��5/      $
��Left=�6.   $��266,260,0,0q�6I   $	��Top=�6^   �� 50      $��Deadline��6   $
��Left=�6'   $��266,229,0,0q�6B   $	��Top=�6W   �� 51      -   5         ��Name$ btnApply��51      $��Apply��6'   $
��Left=�67   $��426,346,0,0q�6R   $	��Top=�6g   $	��204��6   $��63��6�     MaterialDesignFlatButton#��[ 6�   �� 52      -   5        $ 	btnCancel��52      $��Cancel��6(   $
��Left=�69   $��635,346,0,0q�6T   $	��Top=�6i   $	��147��6�   $��63��6�    " MaterialDesignFlatAccentButton#��[ 6�   �� 53      -   5        $ btnCatalogNameAuto��53      $
��Auto��61   $
��Left=�6@   $��224,122,0,0q�6[   $	��Top=�6p   $��71��6�   $��23��6�      MaterialDesignOutlinedButton#��[ 6�   �� 54      -   5         ��Name$ lblID��54      $	��---��6#   $
��Left=�61   $��
37,385,0,0q�6L   $	��Top=�6`   �� 55      $	��ID:��6   $
��Left=�6"   $��
11,385,0,0q�6=   $	��Top=�6Q   �� 56      -   5        $ tbxCatalogPath��56      $
��Left=�6.   $��23��6I   $��224,176,0,0q�6U   $
 Wrap=�6j   $�� ��6~   $	��Top=�6�   $	��197��6�   �� 57      -   5        $ btnCatalogPathAuto��57      $��0,0,0,0q�61   $��Catalog path��6C   $
��Left=�6Z   $��129,176,0,0q�6u   $	��Top=�6�   $��88��6�   $��23��6�   #��[ 6�   �� 58      -   5         ��Name$ chkbxCreateCatalogInPath��58      $��Create catalog in path��69   $
��Left=�6Z   $��128,206,0,0q�6u   $	��Top=�6�   5:      5;      5<      