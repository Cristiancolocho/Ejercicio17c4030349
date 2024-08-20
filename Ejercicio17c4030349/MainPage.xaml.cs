namespace Ejercicio17c4030349
{
    public partial class MainPage : ContentPage
    {
        private readonly LocalDbService _dbService;
        private int _editClientesId;

        public MainPage(LocalDbService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
            Task.Run(async () => listview.ItemsSource = await _dbService.GetClientes());
        }

        private async void listview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var clientes = (Clientes)e.Item;
            var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

            switch (action)
            {
                case "Edit":
                    _editClientesId = clientes.Id;
                    nombreEntryField.Text = clientes.NombreCliente;
                    Entryarea.Text = clientes.Area;
                    EntryTasaPorCuadrado.Text = clientes.TasaPorCuadrado;
                    labelresultado.Text = clientes.Presupuesto;
                    break;

                case "Delete":
                    await _dbService.Delete(clientes);
                    listview.ItemsSource = await _dbService.GetClientes();
                    break;
            }
        }

        private async void PresupuestoBtn_Clicked(object sender, EventArgs e)
        {           

            if (_editClientesId == 0)
            {                
                int N1 = Convert.ToInt32(Entryarea.Text);
                int N2 = Convert.ToInt32(EntryTasaPorCuadrado.Text);
                int resultado = N1 * N2;
                               

                // Mostrar el resultado en el label
                labelresultado.Text = resultado.ToString();

                //agrega presupuesto
                await _dbService.Create(new Clientes
                {
                    NombreCliente = nombreEntryField.Text,
                    Area  = Entryarea.Text,
                    TasaPorCuadrado = EntryTasaPorCuadrado.Text,
                    Presupuesto = labelresultado.Text
                                   
                });
            }
            else
            {
                int N1 = Convert.ToInt32(Entryarea.Text);
                int N2 = Convert.ToInt32(EntryTasaPorCuadrado.Text);
                int resultado = N1 * N2;


                // Mostrar el resultado en el label
                labelresultado.Text = resultado.ToString();
                //Edita cliente
                await _dbService.Update(new Clientes
                {
                    Id = _editClientesId,
                    NombreCliente = nombreEntryField.Text,
                    Area = Entryarea.Text,
                    TasaPorCuadrado = EntryTasaPorCuadrado.Text,
                    Presupuesto = labelresultado.Text
                });
                _editClientesId = 0;
            }
            nombreEntryField.Text = string.Empty;
            Entryarea.Text = string.Empty;
            EntryTasaPorCuadrado.Text = string.Empty;
            labelresultado.Text = string.Empty;

            listview.ItemsSource = await _dbService.GetClientes();
        }
    }

}
