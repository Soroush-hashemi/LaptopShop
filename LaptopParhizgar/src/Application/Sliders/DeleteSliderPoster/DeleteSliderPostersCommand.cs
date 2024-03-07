using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sliders.DeleteSliderPoster;
public record DeleteSliderPostersCommand(long SliderPosterId) : IBaseCommand;