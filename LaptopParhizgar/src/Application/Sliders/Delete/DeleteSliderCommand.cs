using Common.Application;

namespace Application.Sliders.Delete;
public record DeleteSliderCommand(long SliderId) : IBaseCommand;