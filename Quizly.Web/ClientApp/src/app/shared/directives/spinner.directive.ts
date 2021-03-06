import { Directive, ElementRef, Input, OnChanges, Renderer }  from "@angular/core";


@Directive({
    selector: '[spinner]'
})
export class SpinnerDirective implements OnChanges {
    @Input('spinner') isBusy: boolean;
    @Input() overlay = false;

    private busyClassName = 'loading-spinner';
    private overlayClassName = 'overlay';

    constructor(
        private element: ElementRef,
        private renderer: Renderer) {
    }

    ngOnChanges(changes: Object): void {
        this.setIsBusy();
    }

    private setIsBusy(): void {
        this.renderer.setElementClass(this.element.nativeElement, this.busyClassName, this.isBusy);
        if (this.overlay)
            this.renderer.setElementClass(this.element.nativeElement, this.overlayClassName, this.isBusy);
    }
}
