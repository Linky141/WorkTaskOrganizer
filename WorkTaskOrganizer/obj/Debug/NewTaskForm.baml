   M S B A M L   `   `   `  ����L  HWorkTaskOrganizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WorkTaskOrganizerWorkTaskOrganizer  5   	   #    WorkTaskOrganizer.NewTaskForm   5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5
   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WorkTaskOrganizer     5   	   -   5          �Name$  window��5   .      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5	   	    � Title$	 ---��5   	   $	��455��6   $	��807��6"    � 
ResizeMode$ NoResize=�6>    � WindowStartupLocation$ CenterScreen=�6T   .��5      � .+�5   
   �� $��Task status��6   $
��Left=�6&   $��10,9,0,0q�6A   $	��Top=�6S   	� 5   
   -   5         	�Name$ rbTaskStatusReloadOnProd��5       	� 	GroupName$ 
TaskStatus��68   $��Reload on prod��6O   $
��Left=�6h   $��
11,150,0,0q�6�   $	��Top=�6�   	� 5   
   -   5        $ rbTaskStatusQuestionToPM��5      $ 
TaskStatus��68   $��Question to PM��6O   $
��Left=�6h   $��
10,104,0,0q�6�   $	��Top=�6�   	� 5   
   -   5        $ rbTaskStatusOpen��5      $ 
TaskStatus��60   $
��Open��6G   $
��Left=�6V   $��	10,58,0,0q�6q   $	��Top=�6�   	� 5   
   -   5        $ rbTaskStatusClosed��5      $ 
TaskStatus��62   $��Closed��6I   $
��Left=�6Z   $��	10,81,0,0q�6u   $	��Top=�6�   	� 5   
   -   5        $ rbTaskStatusOnTests��5      $ 
TaskStatus��63   $��On tests��6J   $
��Left=�6]   $��
11,127,0,0q�6x   $	��Top=�6�   	� 5   
   -   5        $ rbTaskStatusNotStarted��5      $ 
TaskStatus��66   $��Not started��6M   $
��Left=�6c   $��	10,35,0,0q�6~   $	��Top=�6�   �� 5   
   $��Priority��6   $
��Left=�6#   $��
10,186,0,0q�6>   $	��Top=�6R   	� 5   
   -   5        $ rbTaskPriority1��5      $ Priority��6/   $��1 - Blocker��6D   $
��Left=�6Z   $��
10,212,0,0q�6u   $	��Top=�6�   	� 5   
   -	   5        $ rbTaskPriority2��5      $ Priority��6/   $��2 - Critical��6D   $
��Left=�6[   $��
10,235,0,0q�6v   $	��Top=�6�   	� 5   
   -
   5        $ rbTaskPriority3��5      $ Priority��6/   $��	3 - Major��6D   $
��Left=�6X   $��
10,258,0,0q�6s   $	��Top=�6�   	� 5   
   -   5        $ rbTaskPriority4��5      $ Priority��6/   $��	4 - Minor��6D   $
��Left=�6X   $��
10,281,0,0q�6s   $	��Top=�6�   	� 5   
   -   5        $ rbTaskPriority5��5      $ Priority��6/   $��5 - Trivial��6D   $
��Left=�6Z   $��
10,304,0,0q�6u   $	��Top=�6�   �� 5   
   $��Format��6   $
��Left=�6!   $��131,293,0,0q�6<   $	��Top=�6Q   	� 5    
   -   5        $ rbTaskFormatE1��5    5   $ Format��6M   $��E1��6`   $
��Left=�6m   $��131,319,0,0q�6�   $	��Top=�6�   	� 5!   
   -   5        $ rbTaskFormatE2��5!   5   $ Format��6M   $��E2��6`   $
��Left=�6m   $��131,342,0,0q�6�   $	��Top=�6�   	� 5"   
   -   5        $ rbTaskFormatAnother��5"   5   $ Format��6R   $��Another��6e   $
��Left=�6w   $��131,365,0,0q�6�   $	��Top=�6�   �� 5#   
   -   5         ��Name$ tbxFormatAnother��5#      $
��Left=�6,   $��22��6G   $��131,388,0,0q�6S   	 �� TextWrapping$
	 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��290��6�   �� 5$   
   $��	Task name��6   $
��Left=�6$   $��	131,4,0,0q�6?   $	��Top=�6R   �� 5%   
   -   5        $ tbxTaskName��5%      $
��Left=�6'   $��23��6B   $��
131,30,0,0q�6N   $
	 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��290��6�   �� 5&   
   $��Link to Jira��6   $
��Left=�6'   $��
131,64,0,0q�6B   $	��Top=�6V   �� 5'   
   -   5        $ tbxLinkToJira��5'      $
��Left=�6)   $��23��6D   $��
131,90,0,0q�6P   $
	 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��290��6�   �� 5(   
   $��Comment��6   $
��Left=�6"   $��	426,5,0,0q�6=   $	��Top=�6P   $��33��6h   �� 5)   
   -   5        $ 	tbxComent��5)      "
 �� VerticalScrollBarVisibility$

 Auto=�6&   $ �� HorizontalScrollBarVisibility$
 Auto=�6I    �� AcceptsReturn . $
��Left=�6�   $	��311��6�   $��
426,30,0,0q�6�   $	 NoWrap=�6�   $�� ��6�   $	��Top=�6�   $	��359��6�   �� 5*   
   $��Catalog name��6   $
��Left=�6'   $��131,122,0,0q�6B   $	��Top=�6W   �� 5+   
   -   5        $ tbxCatalogName��5+      $
��Left=�6*   $��23��6E   $��131,148,0,0q�6Q   $
	 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��290��6�   (  "System.Windows.Controls.DatePicker  5,   
   -   5          Name$ calCreationDate��5,      $
��Left=�6.   $��128,260,0,0q�6I   $	��Top=�6^   �� 5-   
   $��Creation date��6   $
��Left=�6(   $��128,229,0,0q�6C   $	��Top=�6X     5.   
   -   5        $ calDeadline��5.      $
��Left=�6*   $��266,260,0,0q�6E   $	��Top=�6Z   �� 5/   
   $��Deadline��6   $
��Left=�6#   $��266,229,0,0q�6>   $	��Top=�6S   �� 50   
   -   5         ��Name$ btnApply��50      $��Apply��6#   $
��Left=�63   $��426,346,0,0q�6N   $	��Top=�6c   $	��204��6{   $��63��6�   6�   �� 51   
   -   5        $ 	btnCancel��51      $��Cancel��6$   $
��Left=�65   $��635,346,0,0q�6P   $	��Top=�6e   $	��147��6}   $��63��6�   6�   �� 52   
   -   5        $ btnCatalogNameAuto��52      $
��Auto��6-   $
��Left=�6<   $��224,122,0,0q�6W   $	��Top=�6l   $��71��6�   $��23��6�   6�   �� 53   
   -   5         ��Name$ lblID��53      $	��---��6   $
��Left=�6-   $��
37,385,0,0q�6H   $	��Top=�6\   �� 54   
   $	��ID:��6   $
��Left=�6   $��
11,385,0,0q�69   $	��Top=�6M   �� 55   
   -   5        $ tbxCatalogPath��55      $
��Left=�6*   $��23��6E   $��224,176,0,0q�6Q   $
	 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��197��6�   �� 56   
   -   5        $ btnCatalogPathAuto��56      $��0,0,0,0q�6-   $��Catalog path��6?   $
��Left=�6V   $��129,176,0,0q�6q   $	��Top=�6�   $��88��6�   $��23��6�   6�   �� 57   
   -   5         ��Name$ chkbxCreateCatalogInPath��57      $��Create catalog in path��65   $
��Left=�6V   $��128,206,0,0q�6q   $	��Top=�6�   59      5:      