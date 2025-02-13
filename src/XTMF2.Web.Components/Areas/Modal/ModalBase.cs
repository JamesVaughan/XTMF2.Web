using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace XTMF2.Web.Components {

	public class ModalBase : ComponentBase {

		[Inject]
		public IJSRuntime JsRuntime { get; set; }

		protected ElementReference modalElement;

		[Parameter]
		public RenderFragment Content { get; set; }

		[Parameter]
		public RenderFragment Title { get; set; }

		[Parameter]
		public string ModalName { get; set; }

		[Parameter]
		public string ConfirmText { get; set; } = "Confirm";

		protected bool IsShow { get; set; } = false;

		protected string ShowClass => IsShow ? "show" : "";

		[Parameter]
		public EventCallback<EventArgs> OnConfirm { get; set; }

		[Parameter]
		public EventCallback<EventArgs> OnCancel { get; set; }

		public async void Show () {
			await JsRuntime.InvokeAsync<object> ("xtmf2WebComponents.Modal.showModal", ModalName);
			this.IsShow = true;
		}

		public async void Hide () {
			await JsRuntime.InvokeAsync<object> ("xtmf2WebComponents.Modal.showModal", ModalName);
			this.IsShow = true;
		}

		public void Confirm (EventArgs e) {
			this.IsShow = false;
			OnConfirm.InvokeAsync (e);
		}

		public void Cancel (EventArgs e) {
			this.IsShow = false;
			OnCancel.InvokeAsync (e);
		}
	}
}