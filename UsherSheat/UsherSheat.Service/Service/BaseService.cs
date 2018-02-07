namespace UsherSheat.Service.Service
{
    public class BaseService
    {
        protected IUnitOfWork Uow;

        public BaseService(IUnitOfWork uow)
        {            
            Uow = uow;
        }
    }
}
