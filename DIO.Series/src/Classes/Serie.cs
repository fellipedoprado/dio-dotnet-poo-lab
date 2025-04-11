

namespace DIO.Series
{
    public class Serie : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool IsDeleted { get; set; }

        public Serie(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.IsDeleted = false;
        }

        public override string ToString()
        {
            try
            {
                string retorno = "";
                retorno += "Gênero: " + this.Genre + Environment.NewLine;
                retorno += "Título: " + this.Title + Environment.NewLine;
                retorno += "Descrição: " + this.Description + Environment.NewLine;
                retorno += "Ano de Início: " + this.Year + Environment.NewLine;
                retorno += "Excluído: " + this.IsDeleted;
                return retorno;
            }
            catch (Exception ex)
            {

                return $"Erro ao gerar string de saída: {ex.Message}";
            }

        }

        public string GetTitle()
        {
            return this.Title;
        }

        public int GetId()
        {
            return this.Id;
        }

        public void Delete()
        {
            this.IsDeleted = true;
        }
        public bool GetIsDeleted()
        {
            return this.IsDeleted;
        }
        /* public void setIsDeleted(bool isDeleted)
        {
            this.IsDeleted = isDeleted;
        } */
    }
}