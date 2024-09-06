using DevOps_Boards.Data.Dto;
using DevOps_Boards.Data.Model;
using FluentValidation;

namespace DevOps_Boards.FluentValidation
{
	public class CardValidation :AbstractValidator<CardDto> 
	{
		public CardValidation()
		{
			RuleFor(card => card.Title).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20).Must(Titleisvalidat).When(card=>card.Title!=null);
			RuleFor(card => card.Description).NotNull().NotEmpty().Length(5,255);
			RuleFor(caed => caed.status).NotNull().NotEmpty().Must(isvValidStatus);
		}

		private bool isvValidStatus(Status status)
		{
			if (status == Status.Done)
				return true;
			if (status == Status.In_Progress)
				return true;
			if (status == Status.To)
				return true;
			return false;
		}

		private bool Titleisvalidat(string arg)
		{
			return arg.All(char.IsLetter);
		}
	}
}
