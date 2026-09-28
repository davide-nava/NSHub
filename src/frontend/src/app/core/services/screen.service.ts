import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { computed, inject, Injectable, signal } from '@angular/core';
import { ScreenSizes } from '@core/models';

@Injectable({
  providedIn: 'root',
})
export class ScreenService {
  private readonly breakpointObserver = inject(BreakpointObserver);

  private readonly xSmallMatch = signal(this.breakpointObserver.isMatched(Breakpoints.XSmall));
  private readonly smallMatch = signal(this.breakpointObserver.isMatched(Breakpoints.Small));
  private readonly mediumMatch = signal(this.breakpointObserver.isMatched(Breakpoints.Medium));
  private readonly largeMatch = signal(
    this.breakpointObserver.isMatched(Breakpoints.Large) ||
      this.breakpointObserver.isMatched(Breakpoints.XLarge),
  );

  readonly sizes = computed<ScreenSizes>(() => ({
    'screen-x-small': this.xSmallMatch(),
    'screen-small': this.smallMatch(),
    'screen-medium': this.mediumMatch(),
    'screen-large': this.largeMatch(),
  }));

  readonly isXSmall = computed(() => this.xSmallMatch());
  readonly isLarge = computed(() => this.largeMatch());

  constructor() {
    this.breakpointObserver
      .observe([
        Breakpoints.XSmall,
        Breakpoints.Small,
        Breakpoints.Medium,
        Breakpoints.Large,
        Breakpoints.XLarge,
      ])
      .subscribe(() => {
        this.xSmallMatch.set(this.breakpointObserver.isMatched(Breakpoints.XSmall));
        this.smallMatch.set(this.breakpointObserver.isMatched(Breakpoints.Small));
        this.mediumMatch.set(this.breakpointObserver.isMatched(Breakpoints.Medium));
        this.largeMatch.set(
          this.breakpointObserver.isMatched(Breakpoints.Large) ||
            this.breakpointObserver.isMatched(Breakpoints.XLarge),
        );
      });
  }
}
