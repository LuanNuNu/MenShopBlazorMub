window.exportInvoiceToPdf = function (elementId, filename = 'invoice.pdf') {
    var element = document.getElementById(elementId);
    if (!element) {
        console.error("Không tìm thấy element để in!");
        return;
    }

    html2pdf().from(element).set({
        margin: 10,
        filename: filename,
        html2canvas: { scale: 2 },
        jsPDF: { unit: 'mm', format: 'a4', orientation: 'portrait' }
    }).save();
};
