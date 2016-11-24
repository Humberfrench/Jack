namespace Jack.Application.ViewModel
{
    public class KitItemViewModel
    {

        public virtual int Codigo { get; set; }
        public virtual TipoItemViewModel TipoItem { get; set; }
        public virtual int Ordem { get; set; }
        public virtual string Observacao { get; set; }
        public virtual KitViewModel Kit { get; set; }

    }
}
