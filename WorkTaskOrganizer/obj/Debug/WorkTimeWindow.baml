   M S B A M L   `   `   `  ����L  HWorkTaskOrganizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WorkTaskOrganizerWorkTaskOrganizer  5   	   &     WorkTaskOrganizer.WorkTimeWindow   5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5
   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WorkTaskOrganizer     5   	   -   5           MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5	   	    � Title$ WorkTimeWindow��5   	   $	��950��6    $��388.141��6-    � 
ResizeMode$ NoResize=�6=    � WindowStartupLocation$ CenterScreen=�6S   
������  � AllowsTransparency .  � WindowStyle$
 None=�5   <   .��5      ��   MaterialDesignPaper#���  6    �� CornerRadius$ 10��6@   $��1q�6R   ���#eeee._�5   
   � .+�5      �� $��	Work date��6   $
��Left=�6(   $��	10,10,0,0q�6C   $	��Top=�6V   �� 5      -   5         ��Name$ lbxStartHour��5      $
��Left=�6]   $	��774��6x   $��
10,127,0,0q�6�   $	��Top=�6�   $��77��6�   �� 5      -   5        $ lbxStartMinute��5      $
��Left=�6a   $	��774��6|   $��
92,127,0,0q�6�   $	��Top=�6�   $��77��6�   �� 5      $
��Hour��6   $
��Left=�6#   $��	10,96,0,0q�6>   $	��Top=�6Q   �� 5      $��Minute��6   $
��Left=�6%   $��	92,96,0,0q�6@   $	��Top=�6S   �� 5      -   5        	 ��Name$	 btnOk��5      $��Ok��6$   $
��Left=�61   $��	9,906,0,0q�6L   $	��Top=�6_   $	��183��6w     MaterialDesignFlatButton#��[ 6�   �� 5      -   5        $	 	btnCancel��5      $��Cancel��6(   $
��Left=�69   $��197,906,0,0q�6T   $	��Top=�6i   $	��179��6�    " MaterialDesignFlatAccentButton#��[ 6�   �� 5      -   5        $ 
lbxEndHour��5      $
��Left=�6Y   $	��774��6t   $��198,127,0,0q�6�   $	��Top=�6�   $��77��6�   �� 5      -   5        $ lbxEndMinute��5      $
��Left=�6]   $	��774��6x   $��300,127,0,0q�6�   $	��Top=�6�   $��77��6�   �� 5      $
��Hour��6   $
��Left=�6#   $��
198,96,0,0q�6>   $	��Top=�6R   �� 5      $��Minute��6   $
��Left=�6%   $��
300,96,0,0q�6@   $	��Top=�6T   
 J� RenderTransformOrigin$
 5.576,0.706&�6l   �� 5      -   5         ��Name$ 
lblPreview��5      $	��---��6(   $
��Left=�66   $��	92,10,0,0q�6Q   $	��Top=�6d   (  "System.Windows.Controls.DatePicker  5       -	   5          Name$ calStartWork��5    P   $
��Left=�6f   $��	10,41,0,0q�6�   $	��Top=�6�   $	��367��6�   �� 5!      $��Start��6   $
��Left=�6$   $��	10,70,0,0q�6?   $	��Top=�6R   �� 5"      $	��End��6   $
��Left=�6"   $��
198,70,0,0q�6=   $	��Top=�6Q   �� 5#      -
   5        $	 btnStartClear��5#      $��clear��6,   $
��Left=�6<   $��	49,71,0,0q�6W   $	��Top=�6j   $	��120��6�   $��23��6�   #��[ 6�   6�   �� 5$      -   5        $	 btnEndClear��5$      $��clear��6*   $
��Left=�6:   $��
233,71,0,0q�6U   $	��Top=�6i   $	��120��6�   $��23��6�   #��[ 6�   6�   5&      5'      5(      