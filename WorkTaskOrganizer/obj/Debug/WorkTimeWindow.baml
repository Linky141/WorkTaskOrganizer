   M S B A M L   `   `   `  ����L  HWorkTaskOrganizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WorkTaskOrganizerWorkTaskOrganizer  5   	   &     WorkTaskOrganizer.WorkTimeWindow   5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5
   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WorkTaskOrganizer     5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5	   	    � Title$ WorkTimeWindow��5   	   $��499.5��6    $��400.67��6/    � 
ResizeMode$ NoResize=�6>    � WindowStartupLocation$ CenterScreen=�6T   .��5      � .+�5   
   �� $��	Work date��6   $
��Left=�6$   $��	10,10,0,0q�6?   $	��Top=�6R   �� 5   
   -   5         ��Name$ lbxStartHour��5      $
��Left=�6Y   $	��282��6t   $��
10,127,0,0q�6�   $	��Top=�6�   $��77��6�   �� 5   
   -   5        $ lbxStartMinute��5      $
��Left=�6]   $	��282��6x   $��
92,127,0,0q�6�   $	��Top=�6�   $��77��6�   �� 5   
   $
��Hour��6   $
��Left=�6   $��	10,96,0,0q�6:   $	��Top=�6M   �� 5   
   $��Minute��6   $
��Left=�6!   $��	92,96,0,0q�6<   $	��Top=�6O   �� 5   
   -   5         ��Name$ btnOk��5      $��Ok��6    $
��Left=�6-   $��
10,421,0,0q�6H   $	��Top=�6\   $	��183��6t   6�   �� 5   
   -   5        $ 	btnCancel��5      $��Cancel��6$   $
��Left=�65   $��198,421,0,0q�6P   $	��Top=�6e   $	��179��6}   6�   �� 5   
   -   5        $ 
lbxEndHour��5      $
��Left=�6U   $	��282��6p   $��198,127,0,0q�6}   $	��Top=�6�   $��77��6�   �� 5   
   -   5        $ lbxEndMinute��5      $
��Left=�6Y   $	��282��6t   $��300,127,0,0q�6�   $	��Top=�6�   $��77��6�   �� 5   
   $
��Hour��6   $
��Left=�6   $��
198,96,0,0q�6:   $	��Top=�6N   �� 5   
   $��Minute��6   $
��Left=�6!   $��
300,96,0,0q�6<   $	��Top=�6P    J� RenderTransformOrigin$ 5.576,0.706&�6h   �� 5   
   -   5         ��Name$ 
lblPreview��5      $	��---��6$   $
��Left=�62   $��	92,10,0,0q�6M   $	��Top=�6`   (  "System.Windows.Controls.DatePicker  5   
   -   5        	  Name$	 calStartWork��5   L   $
��Left=�6b   $��	10,41,0,0q�6}   $	��Top=�6�   $	��367��6�   �� 5   
   $��Start��6   $
��Left=�6    $��	10,70,0,0q�6;   $	��Top=�6N   �� 5    
   $	��End��6   $
��Left=�6   $��
198,70,0,0q�69   $	��Top=�6M   5"      5#      