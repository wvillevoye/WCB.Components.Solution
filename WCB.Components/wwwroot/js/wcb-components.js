// File: WCB.Components/wwwroot/js/wcb-components.js
// This JavaScript file initializes Bootstrap Toast and Modal components
// and handles the 'hidden.bs.toast' event to notify Blazor.

// Functions for Toasts
export function initToasts(dotNetObjectRef) {
    if (typeof bootstrap === 'undefined') {
        return;
    }

    setTimeout(() => {
        const toastElList = document.querySelectorAll('.toast:not([data-bs-initialized])');
        toastElList.forEach(toastEl => {
            if (!document.body.contains(toastEl)) {
                console.warn(`Toast element not found in DOM, likely already removed by Blazor: ${toastEl.querySelector('.toast-body')?.textContent.trim()}`);
                return;
            }

            toastEl.setAttribute('data-bs-initialized', 'true');
            const toast = new bootstrap.Toast(toastEl);
            toast.show();

            toastEl.addEventListener('hidden.bs.toast', () => {
                const toastBody = toastEl.querySelector('.toast-body');
                if (toastBody) {
                    dotNetObjectRef.invokeMethodAsync('ToastHidden', toastBody.textContent.trim());
                }
            });
        });
    }, 50);
}

// Functions for Modals
export function showModal(id) {
    const modalElement = document.getElementById(id);
    if (modalElement) {
        const modal = new bootstrap.Modal(modalElement);
        modal.show();
    } else {
        console.error(`Modal element with ID '${id}' not found.`);
    }
}

export function hideModal(id) {
    const modalElement = document.getElementById(id);
    if (modalElement) {
        const modal = bootstrap.Modal.getInstance(modalElement);
        if (modal) {
            modal.hide();
        } else {
            modalElement.classList.remove('show');
            modalElement.setAttribute('aria-hidden', 'true');
            modalElement.style.display = 'none';
            document.body.classList.remove('modal-open');
        }
    }
}
export function showOffcanvas(id) {
    const offcanvasElement = document.getElementById(id);
    if (offcanvasElement) {
        const offcanvas = new bootstrap.Offcanvas(offcanvasElement);
        offcanvas.show();
    } else {
        console.error(`Offcanvas element with ID '${id}' not found.`);
    }
}
