using System;
using Game.Content.Environment;
using UniRx;
using Zenject;

namespace Game.View
{
    public class IncludedPlatformPresenter : IInitializable, IDisposable
    {
        private readonly IncludedPlatform _platform;
        private readonly IncludedPlatformView _view;

        private readonly CompositeDisposable _disposable = new();

        public IncludedPlatformPresenter(IncludedPlatform platform, IncludedPlatformView view)
        {
            _platform = platform;
            _view = view;
        }

        public void Initialize()
        {
            _platform.PlatformEnabled.Subscribe(_view.StartLeverAnimation).AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}