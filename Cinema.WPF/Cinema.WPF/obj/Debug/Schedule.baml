   M S B A M L   `   `   `  ����E  ACinema.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Cinema.WPF.ViewModelCinema.WPF.ViewModel  5   	       Cinema.WPF.Schedule   5   	   X TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Cinema.WPF.ViewModel     5   	   -   5          �Name$  change��5   @    � Title$ Schedule��5   	   $��626.572��6   $��751.713��6+    � DataContext 5	      ,  &Cinema.WPF.ViewModel.ScheduleViewModel  5
   
   6$   .��5e      � -   5        $��myGrid��5e       � ColumnDefinitions 5f   
   �� 5g      $��50 �6   �� 5h      $	��150 �6   �� 5i      $	��120 �6   �� 5j      $��* �6    � RowDefinitions 5l   
   �� 5m      $��35 �6   �� 5n      $��65 �6   �� 5o      $��* �6   .+�5r   
   �� $��Search��6   $��Center=�6!   $��Right=�6<   $��2��6X   $��0,6,49,3q�6h   �� 5s   
   $��2��62   $��
76,7,328,3q�6B   $��2��6V   ��6   �� *SearchCriteria+6V   �� 5t   
   $��Search��6   $��3��5u      $��	103,4,0,0q�6!   $
��Left=�64   $	��100��6O   ��5t   "   �� *Search+5u   O   �� 5v   
   $
��Save��6   $��3��5w      $��257,16,0,18q�6!   $
��Left=�66   $	��100��6Q   $��1��6]   ��5v       �� *Save+5w   ]   �� 5x   
   -   5         ��Name$	 cb1��5z       �� DisplayMemberPath$ title��5x   3    �� SelectedValuePath$ title��5y      $
��Left=�5z       $��	10,19,0,0q�6;   $��1��6N   $	��Top=�6[   $	��135��6s   $��2��6   ��5x      �� *Films+ �� SelectedValue 5y   -   �� *SelIt2+5z      �� 5{   
   -   5        $	 cb2��5}      $
 name��5{   2   $
 name��5|      $��2��5}       $
��Left=�64   $��
100,19,0,0q�6O   $��1��6c   $	��Top=�6p   $��86��6�   $��1��6�   ��5{      �� *halls+ 5|   ,   �� *SelIt3+5}   �   �� 5~   
   -   5        $	��add��5~      $	��ADD��6   $��1��6B   $��30��6O   $��3��5      $��132,16,0,19q�6!   $
��Left=�66   $	��100��6Q   ��5~   *   �� *ADD+5   ]   (  "System.Windows.Controls.DatePicker  5�   
   -   5        $��dp��5�      $��2��6M   $
��Left=�6]   $��	41,19,0,0q�6x   $��1��6�   $	��Top=�6�   $��95��6�   $��2��6�   	   SelectedDate	 6   �� *	SelDate+
 �� Mode$
 TwoWay=�6�   �� 5�   
   -   5         ��Name$	 tb1��5�      $��3��66   $
��Left=�6F   $��23��6a   $��	21,18,0,0q�6m   $��1��6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $��26��6�   ��6   �� *hours+6�   �� 5�   
   -   5         ��Name$ label��5�      $��:��6    $��3��6,   $
��Left=�6<   $��	52,15,0,0q�6W   $��1��6j   $	��Top=�6w   �� 5�   
   -	   5        $	 tb2��5�      $��3��64   $
��Left=�6D   $��23��6_   $��	67,18,0,0q�6k   $��1��6~   $
 Wrap=�6�   $	��Top=�6�   $��26��6�   ��6   �� *min+6�   &   System.Windows.Controls.DataGrid  5�   
      AutoGenerateColumns .  $��2��5�      $��4��6    $��5,5,5,57q�64      RowDetailsVisibilityMode$ VisibleWhenSelected=�5�      ��5�      �� *sesd+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Session ID��6@   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *ses_id+6@     5�      $
 Film��6D    6%   �� *
Film.title+6D     5�      $
 Hall��6C    6%   �� *	Hall.name+6C     5�      $
 date��6A    6%   �� *	sesDate+6A   5�      �� 5�   
   -
   5         ��Name$ button��5�      $
��Done��6!   $��2��60   $
��Left=�6@   $��
57,450,0,0q�6[   $��2��6o   $	��Top=�6|   $	��169��6�   $��2��6�   6�   5�      5�      